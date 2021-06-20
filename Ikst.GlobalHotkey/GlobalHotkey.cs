using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Ikst.GlobalHotkey
{

    /// <summary>
    /// GlobalHotkey
    /// </summary>
    public class GlobalHotkey : Form
    {
        private const int WM_HOTKEY = 0x0312;
        private bool disposedValue = false;
        private Dictionary<int, Action> actionDict = new Dictionary<int, Action>();

        /// <summary>
        /// ホットキーを登録します
        /// </summary>
        /// <param name="modifierKeys">修飾子キー</param>
        /// <param name="key">入力キー</param>
        /// <param name="act">実行処理</param>
        /// <returns>登録ID</returns>
        public int Regist(int modifierKeys, int key, Action act)
        {
            for (int i = 0x0000; i <= 0xbfff; i++)
            {
                if (actionDict.ContainsKey(i)) continue;
                if (NativeMethods.RegisterHotKey(base.Handle, i, modifierKeys, key) != 0)
                {
                    actionDict.Add(i, act);
                    return i;
                }
            }
            return 0;
        }

        /// <summary>
        /// ホットキーを解除します
        /// </summary>
        /// <param name="id">登録時のID</param>
        public void UnRegist(int id)
        {
            NativeMethods.UnregisterHotKey(this.Handle, id);
        }

        /// <summary>
        /// 全てのホットキーを解除します
        /// </summary>
        public void UnRegistAll()
        {
            foreach (var item in actionDict)
            {
                UnRegist(item.Key);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                int id = (int)m.WParam;
                if (actionDict.ContainsKey(id))
                {
                    actionDict[id]();
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                UnRegistAll();
                base.Dispose(disposing);
                disposedValue = true;
            }
        }

        ~GlobalHotkey()
        {
            Dispose(false);
        }
    }
}
