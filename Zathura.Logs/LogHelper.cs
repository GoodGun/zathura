using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace Zathura.Logs
{
    public class LogHelper
    {
        private static ILog _log;
        private static void Setup()
        {
            if (_log != null)
                return;
            _log = LogManager.GetLogger(typeof(LogHelper));

            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            var patternLayout = new PatternLayout { ConversionPattern = "%d{ABSOLUTE} %-5p %c{1}:%L - %m%n" };
            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = false;
            roller.File = @"Logs\EventLog.txt";
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 5;
            roller.MaximumFileSize = "1GB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.StaticLogFileName = true;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            string level = "Error";

            var levelType = typeof(Level);
            foreach (FieldInfo fieldInfo in levelType.GetFields())
            {
                if (fieldInfo.Name == level)
                {
                    try
                    {
                        hierarchy.Root.Level = (Level)fieldInfo.GetValue(null);
                    }
                    catch
                    {
                        hierarchy.Root.Level = Level.Info;
                    }
                    break;
                }
            }

            hierarchy.Configured = true;
        }
        public static void Info(object message)
        {
            Setup();
            if (_log.IsInfoEnabled)
                _log.Info(message);
        }
        public static void Debug(object message)
        {
            Setup();
            if (_log.IsDebugEnabled)
                _log.Debug(message);
        }
        public static void Error(object message)
        {
            Setup();

            if (_log.IsErrorEnabled)
            {
                _log.Error(message);
            }
        }
        public static void Warning(object message)
        {
            Setup();

            if (_log.IsWarnEnabled)
            {
                _log.Warn(message);
            }
        }
        public static void Error(Exception exception, string message)
        {
            Setup();
            if (!_log.IsErrorEnabled) return;

            if (!string.IsNullOrWhiteSpace(message))
                _log.Error(message, exception);
            else
                _log.Error(exception);
        }
        public static void Error(Exception exception)
        {
            Error(exception, null);
        }
        public static void Fatal(Exception exception)
        {
            Setup();
            if (_log.IsFatalEnabled)
            {

                _log.Fatal(exception);
            }

        }
        public static void FatalFormat(string message, params object[] args)
        {
            Setup();
            if (_log.IsFatalEnabled)
            {
                _log.FatalFormat(message, args);
            }
        }
        public static void SendEmail(string body)
        {
            try
            {
                //MailMessage mail = new MailMessage();
                //SmtpClient smtpServer = new SmtpClient("127.0.0.1");
                //mail.From = new MailAddress("mehmetalierdin@gmail.com", "Deneme Mail");
                //mail.Priority = MailPriority.High;
                //string[] mailTOs = SystemSettings.MailServerConfiguration.To.Split(new char[] { ',', ';' });
                //foreach (var email in mailTOs)
                //{
                //    mail.To.Add(email);
                //}

                //mail.Subject = "Zathura Hata";
                //mail.Body = body;

                //smtpServer.Send(mail);
            }
            catch (Exception)
            {

            }
        }
        public static void JobLogInfo(object message)
        {
            Setup();
            _log.Info(message);
        }
    }
}