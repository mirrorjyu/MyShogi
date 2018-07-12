﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using MyShogi.Model.Common.ObjectModel;

namespace MyShogi.Model.Shogi.EngineDefine
{
    /// <summary>
    /// エンジンのoptionとその値のペア
    /// ユーザーの設定した値を保存するのに用いる。
    /// エンジン共通設定用。
    /// </summary>
    [DataContract]
    public class EngineOption
    {
        public EngineOption(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// オプション名
        /// </summary>
        [DataMember]
        public string Name;

        /// <summary>
        /// そこに設定する値
        /// 
        /// 数字なども文字列化してセットする。
        /// type : check のときは、"true"/"false"
        /// UsiOptionクラスに従う。
        /// </summary>
        [DataMember]
        public string Value;
    }

    /// <summary>
    /// エンジンのoptionとその値のペア
    /// ユーザーの設定した値を保存するのに用いる。
    /// エンジン個別設定用。
    /// </summary>
    [DataContract]
    public class EngineOptionForIndivisual
    {
        public EngineOptionForIndivisual(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public EngineOptionForIndivisual(string name, string value, bool followCommonSetting)
        {
            Name = name;
            Value = value;
            FollowCommonSetting = followCommonSetting;
        }

        /// <summary>
        /// オプション名
        /// </summary>
        [DataMember]
        public string Name;

        /// <summary>
        /// そこに設定する値
        /// 
        /// 数字なども文字列化してセットする。
        /// type : check のときは、"true"/"false"
        /// UsiOptionクラスに従う。
        /// </summary>
        [DataMember]
        public string Value;
        
        /// <summary>
        /// エンジン共通設定に従うのか
        /// (エンジン個別設定の時のみ有効)
        /// </summary>
        [DataMember]
        public bool FollowCommonSetting;
    }


    /// <summary>
    /// EngineOptionの配列
    /// 
    /// これは、思考エンジンのプリセットで用いる。
    /// </summary>
    [DataContract]
    public class EngineOptions
    {
        public EngineOptions()
        {
            Options = new List<EngineOption>();
        }

        public EngineOptions(List<EngineOption> options)
        {
            Options = options;
        }

        /// <summary>
        /// nullであれば、丸ごとエンジンの個別設定＋共通設定に従う。
        /// nullでなければ、こちらが優先され、設定していない項目は、エンジンの個別設定＋共通設定に従う。
        /// </summary>
        [DataMember]
        public List<EngineOption> Options;
    }

    /// <summary>
    /// EngineOptionForIndivisualの配列
    /// 
    /// これは、思考エンジンのプリセットで用いる。
    /// </summary>
    [DataContract]
    public class EngineOptionsForIndivisual
    {
        public EngineOptionsForIndivisual()
        {
            Options = new List<EngineOptionForIndivisual>();
        }

        public EngineOptionsForIndivisual(List<EngineOptionForIndivisual> options)
        {
            Options = options;
        }

        /// <summary>
        /// nullであれば、丸ごとエンジンの個別設定＋共通設定に従う。
        /// nullでなければ、こちらが優先され、設定していない項目は、エンジンの個別設定＋共通設定に従う。
        /// </summary>
        [DataMember]
        public List<EngineOptionForIndivisual> Options;
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class EngineOptionDescription
    {
        public EngineOptionDescription(string name,string displayName , 
            string descriptionSimple , string description)
        {
            Name = name;
            DisplayName = displayName;
            DescriptionSimple = descriptionSimple;
            Description = description;
        }

        public EngineOptionDescription(string name, string displayName,
            string descriptionSimple, string description , string comboboxDisplayName)
        {
            Name = name;
            DisplayName = displayName;
            DescriptionSimple = descriptionSimple;
            Description = description;
            ComboboxDisplayName = comboboxDisplayName;
        }

        /// <summary>
        /// (元の)オプション名
        /// ここがnullなら、単なる項目名としてDisplayNameを表示する。
        /// </summary>
        [DataMember]
        public string Name;

        /// <summary>
        /// オプションの表示名(日本語にしておくとわかりやすい)
        /// </summary>
        [DataMember]
        public string DisplayName;

        /// <summary>
        /// 説明文。ダイアログ上に表示される。1文ぐらい。
        /// </summary>
        [DataMember]
        public string DescriptionSimple;

        /// <summary>
        /// 説明文。ダイアログ上に表示される。
        /// </summary>
        [DataMember]
        public string Description;

        /// <summary>
        /// ComboBoxに表示する値に対応する日本語名
        /// 
        /// "var1,日本語1,var2,日本語2"
        /// のようにカンマ区切りで書くとvar1,var2が「日本語1」「日本語2」と日本語化される。
        /// </summary>
        [DataMember]
        public string ComboboxDisplayName;

        /// <summary>
        /// このオプション項目をエンジン設定ダイアログの表示から隠す
        /// 表示から隠したい項目に対しては、これをtrueにしたEngineOptionDescriptionを用意する。
        /// </summary>
        [DataMember]
        public bool Hide;
    }


    /// <summary>
    /// エンジンオプションの共通設定/個別設定でGUI側から用いる用。
    /// data bindできるようにするためにNotifyObjectになっている。
    /// 
    /// こちらは、UI上から設定するため、説明文や、type、min-maxなどが必要。
    /// ゆえに、
    /// ・EngineOptionと同じinterfaceを持ち
    /// さらに、
    /// ・UsiOptionをbuild出来る文字列
    /// ・説明文
    /// を持っている。
    /// 
    /// 説明文はEngineOptionDescriptionsで与えられるから不要か…。
    /// </summary>
    public class EngineOptionForSetting : NotifyObject
    {
        public EngineOptionForSetting(string name , string buildString)
        {
            Name = name;
            BuildString = buildString;
        }

        /// <summary>
        /// オプション名
        /// </summary>
        public string Name;

        /// <summary>
        /// データバインドしている値
        /// </summary>
        public string Value
        {
            get { return GetValue<string>("Value"); }
            set { SetValue<string>("Value", value); }
        }

        /// <summary>
        /// UsiOptionオブジェクトを構築するための文字列。
        /// エンジン共通設定の時のみ有効。
        /// (エンジン個別設定の時は、エンジンから"option"をもらってこの文字列を構築する。)
        /// 
        /// "option name USI_Hash type spin default 256"の
        /// "type spin default 256"
        /// の部分。
        /// 
        /// エンジン共通設定としては、
        /// default値は無視されてValueのほうが採用される。
        /// default値にリセットする時に、default値が採用される。
        /// </summary>
        [DataMember]
        public string BuildString;

        /// <summary>
        /// エンジン共通設定に従うのか
        /// (エンジン個別設定の時のみ有効)
        /// </summary>
        [DataMember]
        public bool FollowCommonSetting
        {
            get { return GetValue<bool>("FollowCommonSetting"); }
            set { SetValue<bool>("FollowCommonSetting", value); }
        }
    }

    /// <summary>
    /// エンジンの共通設定/個別設定に使う用。
    /// </summary>
    [DataContract]
    public class EngineOptionsForSetting
    {
        [DataMember]
        public List<EngineOptionForSetting> Options;

        [DataMember]
        /// <summary>
        /// エンジンのオプションの説明文
        /// これが与えられている場合、この順番で表示され、ここにないoptionは表示されない。
        /// </summary>
        public List<EngineOptionDescription> Descriptions;

        /// <summary>
        /// OptionsのValueを上書きする(そのNameのentryがあれば)
        /// </summary>
        /// <param name="options"></param>
        public void OverwriteEngineOptions(EngineOptions options)
        {
            foreach (var option in options.Options)
            {
                var opt = Options.Find(x => x.Name == option.Name);
                if (opt == null)
                    continue;
                opt.Value = option.Value;
                //opt.FollowCommonSetting = option.FollowCommonSetting;
            }
        }

        public void OverwriteEngineOptions(EngineOptionsForIndivisual options)
        {
            foreach (var option in options.Options)
            {
                var opt = Options.Find(x => x.Name == option.Name);
                if (opt == null)
                    continue;
                opt.Value = option.Value;
                opt.FollowCommonSetting = option.FollowCommonSetting;
            }
        }

        // エンジン共通設定に従う設定であっても、
        // エンジン個別設定のほうの値域を守らないといけないという話はあるか…。まあいいか…。あとで考える。

        /// <summary>
        /// このメンバの持つOptionsの
        /// NameとValueのペアをEngineOptionsとして書き出す
        /// </summary>
        /// <returns></returns>
        public EngineOptions ToEngineOptions()
        {
            var options = new EngineOptions();
            options.Options = new List<EngineOption>();

            foreach (var opt in Options)
                options.Options.Add(new EngineOption(opt.Name, opt.Value));

            return options;
        }

        public EngineOptionsForIndivisual ToEngineOptionsForIndivisual()
        {
            var options = new EngineOptionsForIndivisual();
            options.Options = new List<EngineOptionForIndivisual>();

            foreach (var opt in Options)
                options.Options.Add(new EngineOptionForIndivisual(
                    opt.Name, opt.Value, opt.FollowCommonSetting));

            return options;
        }
    }
}