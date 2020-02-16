using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IINTOS.Data;
using IINTOS.Models;
using IINTOS.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IINTOS.Controllers
{
    public class FileController : Controller
    {

        private readonly IINTOSContext _context;
        private readonly EmailSender _emailSender;
        private readonly UserManager<User> _userManager;
        private readonly IServiceProvider _serviceProvider;
        private string DefaultPassword = "123456";

        public FileController(IINTOSContext context, UserManager<User> userManager, EmailSender emailSender, IServiceProvider serviceProvider)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
            _serviceProvider = serviceProvider;
        }
        public FileResult DownloadFile(int? id)
        {
            UserFile file = _context.UserFile.ToList().Find(p => p.Id == id);
            return File(file.Content, file.ContentType, file.FileName);
        }
    }
}