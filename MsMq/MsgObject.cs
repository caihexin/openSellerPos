using System;
using System.Collections.Generic;
using System.Text;

namespace MsMq
{
   public class MsgObject
    {
        public MsgObject()
       {
             //
           // TODO: Add constructor logic here
          //
        }

        
       private string _subject ="";
       public string subject
       {
            get
          {
              return _subject;
           }
            set
          {
                _subject=value;
           }
        }

      private string _body="";
      public string body
       {
           get
           {
               return _body;
           }
            set
           {
               _body=value;
           }
     
    }


    }
}
