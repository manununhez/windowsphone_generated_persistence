﻿

#pragma checksum "C:\Users\manuelitox\Documents\windowspersistence\ShoppingCartApp\ShoppingCartApp\Views\AudioRecord\Audio.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CD2209948215ABA9EF42AFFC741AC615"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingCartApp.Views
{
    partial class Audio : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.MediaElement playbackElement1; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button CaptureButton; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button StopCaptureButton; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button PlayRecordButton; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///Views/AudioRecord/Audio.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            playbackElement1 = (global::Windows.UI.Xaml.Controls.MediaElement)this.FindName("playbackElement1");
            CaptureButton = (global::Windows.UI.Xaml.Controls.Button)this.FindName("CaptureButton");
            StopCaptureButton = (global::Windows.UI.Xaml.Controls.Button)this.FindName("StopCaptureButton");
            PlayRecordButton = (global::Windows.UI.Xaml.Controls.Button)this.FindName("PlayRecordButton");
        }
    }
}



