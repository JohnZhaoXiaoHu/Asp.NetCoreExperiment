﻿using Dapper;
using Npgsql;
using System;

namespace PostgresqlDemo02
{
    class Program
    {
        static void Main(string[] args)
        {
            var connString = "Server=127.0.0.1;Port=5432;UserId=postgres;Password=postgres2018;Database=TestDB;";
            using (var conn = new NpgsqlConnection(connString))
            {
                //查询
                var paySettings = conn.Query<PaySetting>(@"select * from paysettings");

                var s = "";
                foreach (var paySetting in paySettings)
                {
                    Console.WriteLine(paySetting.ID);

                    var setting = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(paySetting.Setting);
                    Console.WriteLine(setting.WxKey);
                    s = paySetting.Setting;
                }
                //插入
                conn.Execute("insert into paysettings(paytype,setting) values(@paytype,cast(@setting as jsonb))", new { paytype = "AliPay", setting = s});
            }
            Console.WriteLine("Hello World!");
        }
    }
    public class PaySetting
    {
        public int ID { get; set; }

        public string PayType { get; set; }

        public string Setting { get; set; }
    }
    public class WeChatPay
    {
        public string WxMchId { get; set; }
        public string WxAppId { get; set; }
        public string WxKey { get; set; }
        public string SwiftMchId { get; set; }
        public int Weight { get; set; }
        public string MchName { get; set; }
        public string MchType { get; set; }
        public string MchDesc { get; set; }
        public string Memo { get; set; }
        public string SwiftAppId { get; set; }
        public string SwiftKey { get; set; }
        public string PayingBank { get; set; }
    }
}

/*
 -- Table: public.paysettings

-- DROP TABLE public.paysettings;

CREATE TABLE public.paysettings
(
    id integer NOT NULL DEFAULT nextval('"PaySettings_id_seq"'::regclass),
    paytype character varying(128) COLLATE pg_catalog."default",
    setting jsonb,
    CONSTRAINT "PaySettings_pkey" PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.paysettings
    OWNER to postgres;
     
     
     */
