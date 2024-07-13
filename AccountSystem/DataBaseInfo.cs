using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem
{
    public class DataBaseInfo
    {
        public DateTime CreatingDate { get; private set; }
        public DateTime UpdatingDate { get; private set; }
        public DataBaseInfo() => CreatingDate = UpdatingDate = DateTime.Now;
        public DataBaseInfo(DataBaseInfo dataBaseInfo)
        {
            if (dataBaseInfo is null)
                throw new NullReferenceException("DataBaseInfo user info is null!");
            this.CreatingDate = dataBaseInfo.CreatingDate;
            this.UpdatingDate = DateTime.Now;
        }

        public void UpdateData() => UpdatingDate = DateTime.Now;
    }
}
