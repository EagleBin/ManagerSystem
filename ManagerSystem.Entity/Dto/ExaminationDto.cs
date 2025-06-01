using GalaSoft.MvvmLight;
using ManagerSystem.Entity.InformationManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystem.Entity.Dto
{
	/// <summary>
	/// 考次数据传输类
	/// </summary>
    public class ExaminationDto : ViewModelBase
    {
		private Examination _Examination;
		/// <summary>
		/// 考次
		/// </summary>
		public Examination Examination
        {
			get { return _Examination; }
			set { _Examination = value; }
		}



	}
}
