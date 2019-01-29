using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppClientEmpDep
{
    public class Department : INotifyPropertyChanged
    {
        private int _depId;
        private string _depName;

        public Department(string _depName, int _depId)
        {
            DepId = _depId;
            DepName = _depName;
        }

        public int DepId { get => _depId; set => _depId = value; }
        public string DepName
        {
            get => _depName;
            set
            {
                this._depName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DepName)));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{this.DepName}";
        }

    }
}
