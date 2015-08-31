using System.Windows.Forms;
using Autofac;
using SySTarjetas.Core.Infrastructure.IoC;

namespace SySTarjetas.Desktop.Controls
{
    public class BaseForm : Form, IResolvable
    {
        public IContainer IoCContainer { get; set; }
    }
}
