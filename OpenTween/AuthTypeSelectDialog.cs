﻿// OpenTween - Client of Twitter
// Copyright (c) 2023 kim_upsilon (@kim_upsilon) <https://upsilo.net/~upsilon/>
// All rights reserved.
//
// This file is part of OpenTween.
//
// This program is free software; you can redistribute it and/or modify it
// under the terms of the GNU General Public License as published by the Free
// Software Foundation; either version 3 of the License, or (at your option)
// any later version.
//
// This program is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
// or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License
// for more details.
//
// You should have received a copy of the GNU General Public License along
// with this program. If not, see <http://www.gnu.org/licenses/>, or write to
// the Free Software Foundation, Inc., 51 Franklin Street - Fifth Floor,
// Boston, MA 02110-1301, USA.

#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTween.Connection;

namespace OpenTween
{
    public partial class AuthTypeSelectDialog : OTBaseForm
    {
        public TwitterAppToken? Result { get; private set; }

        public AuthTypeSelectDialog()
            => this.InitializeComponent();

        private void OKButton_Click(object sender, EventArgs e)
        {
            TwitterAppToken result;
            if (this.AuthByOAuth1RadioButton.Checked)
            {
                result = new()
                {
                    AuthType = APIAuthType.OAuth1,
                    OAuth1ConsumerKey = ApiKey.Create(this.OAuth1ConsumerKeyTextBox.Text),
                    OAuth1ConsumerSecret = ApiKey.Create(this.OAuth1ConsumerSecretTextBox.Text),
                };
            }
            else if (this.UseTwitterComCookieRadioButton.Checked)
            {
                result = new()
                {
                    AuthType = APIAuthType.TwitterComCookie,
                    TwitterComCookie = this.TwitterComCookieTextBox.Text,
                };
            }
            else
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Result = result;
        }
    }
}