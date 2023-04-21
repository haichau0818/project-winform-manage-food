using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DTO.Cache
{
    public class DTO_Statistic
    {
    
        string total;
        string totalCus;
        string totalProd;
        string totalProdSel;
        public string Total { get => total; set => total = value; }
        public string TotalCus { get => totalCus; set => totalCus = value; }
        public string TotalProd { get => totalProd; set => totalProd = value; }
        public string TotalProdSel { get => totalProdSel; set => totalProdSel = value; }
        public ArrayList Mounth { get => mounth; set => mounth = value; }
        public ArrayList Slmounth1 { get => Slmounth; set => Slmounth = value; }
        public ArrayList Year { get => year; set => year = value; }
        public ArrayList Slyear1 { get => Slyear; set => Slyear = value; }
        public ArrayList Date { get => date; set => date = value; }
        public ArrayList Sldate1 { get => Sldate; set => Sldate = value; }
        public ArrayList TypeProd { get => typeProd; set => typeProd = value; }
        public ArrayList SlTypeProd { get => slTypeProd; set => slTypeProd = value; }
        public ArrayList NamePro { get => namePro; set => namePro = value; }
        public ArrayList SlnamePro { get => slnamePro; set => slnamePro = value; }

        ArrayList mounth = new ArrayList();
        ArrayList Slmounth = new ArrayList();
        ArrayList year = new ArrayList();
        ArrayList Slyear = new ArrayList();
        ArrayList date = new ArrayList();
        ArrayList Sldate = new ArrayList();
        ArrayList typeProd = new ArrayList();
        ArrayList slTypeProd = new ArrayList();
        ArrayList namePro = new ArrayList();
        ArrayList slnamePro = new ArrayList();



    }
}
