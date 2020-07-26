using EFEntity.Configer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFEntity
{
    public class TescDbContext1 : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DBTesc;Integrated Security=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //写对应的配置信息(对表的数据进行约束)

            var cffk = modelBuilder.Entity<config_file_first_kind>();
            cffk.ToTable(nameof(config_file_first_kind));//表名
            cffk.HasKey("ffk_id");//主键
            cffk.Property(e => e.first_kind_id).HasMaxLength(2);
            cffk.Property(e => e.first_kind_name).HasMaxLength(60);

            var cffsk = modelBuilder.Entity<config_file_second_kind>();
            cffsk.ToTable(nameof(config_file_second_kind));//表名
            cffsk.HasKey("fsk_id");//主键
            cffsk.Property(e => e.first_kind_id).HasMaxLength(2);
            cffsk.Property(e => e.first_kind_name).HasMaxLength(60);
            cffsk.Property(e => e.second_kind_id).HasMaxLength(2);
            cffsk.Property(e => e.second_kind_name).HasMaxLength(60);

            var cfftk = modelBuilder.Entity<config_file_third_kind>();
            cfftk.ToTable(nameof(config_file_third_kind));//表名
            cfftk.HasKey("ftk_id");//主键
            cfftk.Property(e => e.first_kind_id).HasMaxLength(2);
            cfftk.Property(e => e.first_kind_name).HasMaxLength(60);
            cfftk.Property(e => e.second_kind_id).HasMaxLength(2);
            cfftk.Property(e => e.second_kind_name).HasMaxLength(60);
            cfftk.Property(e => e.third_kind_id).HasMaxLength(2);
            cfftk.Property(e => e.third_kind_name).HasMaxLength(60);
            cfftk.Property(e => e.third_kind_is_retail).HasMaxLength(2);

            //config_public_char
            var cpc = modelBuilder.Entity<config_public_char>();
            cpc.ToTable(nameof(config_public_char));
            cpc.HasKey("pbc_id");
            cpc.Property(e => e.attribute_kind).HasMaxLength(60);
            cpc.Property(e => e.attribute_name).HasMaxLength(60);

            //config_major_kind
            var cmk = modelBuilder.Entity<config_major_kind>();
            cmk.ToTable(nameof(config_major_kind));
            cmk.HasKey("mfk_id");
            cmk.Property(e => e.major_kind_id).HasMaxLength(2);
            cmk.Property(e => e.major_kind_name).HasMaxLength(60);

            //config_major
            var cm = modelBuilder.Entity<config_major>();
            cm.ToTable(nameof(config_major));
            cm.HasKey("mak_id");
            cm.Property(e => e.major_kind_id).HasMaxLength(2);
            cm.Property(e => e.major_kind_name).HasMaxLength(60);
            cm.Property(e => e.major_id).HasMaxLength(2);
            cm.Property(e => e.major_name).HasMaxLength(60);
            cm.Property(e => e.test_amount).HasMaxLength(2);

            //config_primary_key
            var cpk = modelBuilder.Entity<config_primary_key>();
            cpk.ToTable(nameof(config_primary_key));
            cpk.HasKey("prk_id");

            //config_question_first_kind
            var cqfk = modelBuilder.Entity<config_question_first_kind>();
            cqfk.ToTable(nameof(config_question_first_kind));
            cqfk.HasKey("qfk_id");

            //config_question_second_kind
            var cqsk = modelBuilder.Entity<config_question_second_kind>();
            cqsk.ToTable(nameof(config_question_second_kind));
            cqsk.HasKey("qsk_id");

            //engage_answer_details
            var ead = modelBuilder.Entity<engage_answer_details>();
            ead.ToTable(nameof(engage_answer_details));
            ead.HasKey("and_id");

            //engage_answer
            var ea = modelBuilder.Entity<engage_answer>();
            ea.ToTable(nameof(engage_answer));
            ea.HasKey("ans_id");

            //engage_exam_details
            var eed = modelBuilder.Entity<engage_exam_details>();
            eed.ToTable(nameof(engage_exam_details));
            eed.HasKey("exd_id");

            //engage_exam
            var ee = modelBuilder.Entity<engage_exam>();
            ee.ToTable(nameof(engage_exam));
            ee.HasKey("exa_id");

            //engage_interview
            var ei = modelBuilder.Entity<engage_interview>();
            ei.ToTable(nameof(engage_interview));
            ei.HasKey("ein_id");

            //engage_major_release
            var emr = modelBuilder.Entity<engage_major_release>();
            emr.ToTable(nameof(engage_major_release));
            emr.HasKey("mre_id");

            //engage_resume
            var er = modelBuilder.Entity<engage_resume>();
            er.ToTable(nameof(engage_resume));
            er.HasKey("res_id");

            //engage_subjects
            var es = modelBuilder.Entity<engage_subjects>();
            es.ToTable(nameof(engage_subjects));
            es.HasKey("sub_id");

            //human_file_dig
            var hfd = modelBuilder.Entity<human_file_dig>();
            hfd.ToTable(nameof(human_file_dig));
            hfd.HasKey("hfd_id");

            //human_file
            var hf = modelBuilder.Entity<human_file>();
            hf.ToTable(nameof(human_file));
            hf.HasKey("huf_id");

            //major_change
            var mc = modelBuilder.Entity<major_change>();
            mc.ToTable(nameof(major_change));
            mc.HasKey("mch_id");

            //salary_grant_details
            var sgd = modelBuilder.Entity<salary_grant_details>();
            sgd.ToTable(nameof(salary_grant_details));
            sgd.HasKey("grd_id");

            //salary_grant
            var sg = modelBuilder.Entity<salary_grant>();
            sg.ToTable(nameof(salary_grant));
            sg.HasKey("sgr_id");

            //salary_standard_details
            var ssd = modelBuilder.Entity<salary_standard_details>();
            ssd.ToTable(nameof(salary_standard_details));
            ssd.HasKey("sdt_id");

            //salary_standard
            var ss = modelBuilder.Entity<salary_standard>();
            ss.ToTable(nameof(salary_standard));
            ss.HasKey("ssd_id");

            //Tesc
            var t = modelBuilder.Entity<Tesc>();
            t.ToTable(nameof(Tesc));
            t.HasKey("Id");

            //training
            var ta = modelBuilder.Entity<training>();
            ta.ToTable(nameof(training));
            ta.HasKey("tra_id");

            //users
            var u = modelBuilder.Entity<users>();
            u.ToTable(nameof(users));
            u.HasKey("user_id");
        }

        public DbSet<config_file_first_kind> configs { get; set; }
        public DbSet<config_file_second_kind> second { get; set; }
        public DbSet<config_file_third_kind> third { get; set; }
        public DbSet<config_public_char> publics{ get; set; }
        public DbSet<config_major_kind> cfmk { get; set; }
        public DbSet<config_major> cfm { get; set; }
        public DbSet<users> u { get; set; }
        public DbSet<salary_standard> ss { get; set; }
        public DbSet<salary_standard_details> ssd { get; set; }
        public DbSet<salary_grant> sg { get; set; }
        public DbSet<salary_grant_details> sgd { get; set; }

        public DbSet<human_file> hf { get; set; }
    }
}
