using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace TareaSema7_RobinsonSoplin
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();

    }
}
