﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaTool
{
    /// <summary>
    /// 本検査システムのフォームが持つインターフェイス
    /// </summary>
    public interface IFormForceCancel
    {
        /// <summary>
        /// 外部からの強制キャンセル動作
        /// </summary>
        void ForceCancel();
    }
}
