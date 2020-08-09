using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ado.net连接池
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
/***
 * 当第一次连接数据库的时候，因为连接池中没有任何可用的连接对象，所以第一次要创建一个连接对象
 * 当调用cnn.close()方法的时候，其实并没有关闭连接，二十把连接对象放入到了连接池中
 * 当下次再需要连接数据库的时候，会首先检查连接池中是否有和这次连接使用的连接字符串有没有一样的，如果有一样的
 * 则直接从连接池中取出该对象，如果没有与这次连接使用的连接字符串一样的对象，就新建一个连接对象
 * 
 * 总结：
 * 1、第一次打开连接会创建一个对象
 * 2、当这个连接关闭时（调用close方法），会将当前那个连接对象放入连接池中
 * 3、下一个连接对象，如果连接字符串与池中现有的连接对象的连接字符串完全一样时则会使用池中现有对象，不会创建新对象
 * 4、只有对象使用close方法后这个连接对象才会被放入池中，如果一个连接对象一一直在使用，则下次再创建一个连接对象发现池中没有，就会创建一个新的额连接对象
 * 5、再池中的连接对象，如果过一段时间没有被访问则自动销毁
 * 
 * 什么时候用连接池什么时候不用？
 *      当使用B/S模式时，用户通过web程序访问数据库，使用的都是同一个连接字符串，此时使用连接池
 *      当使用C/S时，客户端的连接字符串不一样，就不使用连接池，防止池中很多对象，占用数据库连接
 * 
 * /