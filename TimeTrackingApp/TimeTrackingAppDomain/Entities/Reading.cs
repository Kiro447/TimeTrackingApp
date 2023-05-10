using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingAppDomain.Enums;

namespace TimeTrackingAppDomain.Entities;

public class Reading : BaseActivity
{
    public int BookPages { get; set; }
    public BookType BookType { get; set; }
    public Reading()
    {
        ActivityType = ActivityType.Reading;
    }
}