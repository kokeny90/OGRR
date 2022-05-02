using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace SGHUORDER.CustomControls
{
    [Serializable]
    public class Files
    {
        string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        string filename1;
        public string Filename1
        {
            get { return filename1; }
            set { filename1 = value; }
        }

        Stream fs;
        public Stream Fs
        {
            get { return fs; }
            set { fs = value; }
        }
        public Files(string filename1, string type, Stream fs)
        {
            this.filename1 = filename1;
            this.type = type;
            this.fs = fs;
        }
        public override string ToString()
        {
            return "files";
        }

    }
}