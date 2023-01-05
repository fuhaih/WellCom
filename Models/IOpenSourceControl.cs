using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellCom.Models
{
    /// <summary>
    /// 服务资源面板
    /// </summary>
    public interface IOpenSourceControl
    {
        public bool IsOpen { get; set; }
    }
}
