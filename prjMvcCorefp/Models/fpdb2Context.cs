using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace prjMvcCorefp.Models
{
    public partial class fpdb2Context : DbContext
    {
        public fpdb2Context()
        {
        }

        public fpdb2Context(DbContextOptions<fpdb2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TApplicationForm> TApplicationForms { get; set; } = null!;
        public virtual DbSet<TBed> TBeds { get; set; } = null!;
        public virtual DbSet<TEmployee> TEmployees { get; set; } = null!;
        public virtual DbSet<TFamilyMember> TFamilyMembers { get; set; } = null!;
        public virtual DbSet<TNursingRecord> TNursingRecords { get; set; } = null!;
        public virtual DbSet<TOffService> TOffServices { get; set; } = null!;
        public virtual DbSet<TOrder> TOrders { get; set; } = null!;
        public virtual DbSet<TPatientInfo> TPatientInfos { get; set; } = null!;
        public virtual DbSet<TProduct> TProducts { get; set; } = null!;
        public virtual DbSet<TRoombed> TRoombeds { get; set; } = null!;
        public virtual DbSet<TShift> TShifts { get; set; } = null!;
        public virtual DbSet<TTake> TTakes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=fpdb2;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TApplicationForm>(entity =>
            {
                entity.HasKey(e => e.AppId)
                    .HasName("PK_外出人員申請資料");

                entity.ToTable("tApplicationForm");

                entity.Property(e => e.AppId).HasColumnName("appId");

                entity.Property(e => e.App事由)
                    .HasMaxLength(50)
                    .HasColumnName("app事由");

                entity.Property(e => e.App修改時間)
                    .HasColumnType("datetime")
                    .HasColumnName("app修改時間");

                entity.Property(e => e.App備註)
                    .HasMaxLength(50)
                    .HasColumnName("app備註");

                entity.Property(e => e.App出發時間)
                    .HasColumnType("datetime")
                    .HasColumnName("app出發時間");

                entity.Property(e => e.App地點)
                    .HasMaxLength(50)
                    .HasColumnName("app地點");

                entity.Property(e => e.App外出日期)
                    .HasColumnType("datetime")
                    .HasColumnName("app外出日期");

                entity.Property(e => e.App審核)
                    .HasMaxLength(50)
                    .HasColumnName("app審核");

                entity.Property(e => e.App申請人)
                    .HasMaxLength(50)
                    .HasColumnName("app申請人");

                entity.Property(e => e.App申請日期)
                    .HasColumnType("datetime")
                    .HasColumnName("app申請日期");

                entity.Property(e => e.App結案)
                    .HasMaxLength(50)
                    .HasColumnName("app結案");

                entity.Property(e => e.App聯絡方式)
                    .HasMaxLength(50)
                    .HasColumnName("app聯絡方式");

                entity.Property(e => e.App返回時間)
                    .HasColumnType("datetime")
                    .HasColumnName("app返回時間");

                entity.Property(e => e.App陪同人員)
                    .HasMaxLength(50)
                    .HasColumnName("app陪同人員");

                entity.Property(e => e.App預計外出時間).HasColumnName("app預計外出時間");

                entity.Property(e => e.EId).HasColumnName("eId");

                entity.Property(e => e.FamId).HasColumnName("famId");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.HasOne(d => d.EIdNavigation)
                    .WithMany(p => p.TApplicationForms)
                    .HasForeignKey(d => d.EId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tApplicationForm_tEmployee");

                entity.HasOne(d => d.Fam)
                    .WithMany(p => p.TApplicationForms)
                    .HasForeignKey(d => d.FamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tApplicationForm_tFamilyMembers");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany(p => p.TApplicationForms)
                    .HasForeignKey(d => d.PId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tApplicationForm_tPatientInfo");
            });

            modelBuilder.Entity<TBed>(entity =>
            {
                entity.HasKey(e => e.BId)
                    .HasName("PK_Bed");

                entity.ToTable("tBed");

                entity.Property(e => e.BId).HasColumnName("bId");

                entity.Property(e => e.B入住時間)
                    .HasMaxLength(50)
                    .HasColumnName("b入住時間");

                entity.Property(e => e.B預計退房時間)
                    .HasMaxLength(50)
                    .HasColumnName("b預計退房時間");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.Property(e => e.RbId).HasColumnName("rbId");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany(p => p.TBeds)
                    .HasForeignKey(d => d.PId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tBed_tPatientInfo");

                entity.HasOne(d => d.Rb)
                    .WithMany(p => p.TBeds)
                    .HasForeignKey(d => d.RbId)
                    .HasConstraintName("FK_tBed_tRoombed");
            });

            modelBuilder.Entity<TEmployee>(entity =>
            {
                entity.HasKey(e => e.EId)
                    .HasName("PK_Employee.Shift");

                entity.ToTable("tEmployee");

                entity.Property(e => e.EId).HasColumnName("eId");

                entity.Property(e => e.EEmail)
                    .HasMaxLength(50)
                    .HasColumnName("eEmail");

                entity.Property(e => e.E修改日期)
                    .HasColumnType("date")
                    .HasColumnName("e修改日期");

                entity.Property(e => e.E修改者工號)
                    .HasMaxLength(50)
                    .HasColumnName("e修改者工號");

                entity.Property(e => e.E到職日期)
                    .HasColumnType("date")
                    .HasColumnName("e到職日期");

                entity.Property(e => e.E員工姓名)
                    .HasMaxLength(50)
                    .HasColumnName("e員工姓名");

                entity.Property(e => e.E員工編號)
                    .HasMaxLength(50)
                    .HasColumnName("e員工編號");

                entity.Property(e => e.E地址)
                    .HasMaxLength(50)
                    .HasColumnName("e地址");

                entity.Property(e => e.E密碼)
                    .HasMaxLength(50)
                    .HasColumnName("e密碼");

                entity.Property(e => e.E建立日期)
                    .HasColumnType("date")
                    .HasColumnName("e建立日期");

                entity.Property(e => e.E建立者工號)
                    .HasMaxLength(50)
                    .HasColumnName("e建立者工號");

                entity.Property(e => e.E性別)
                    .HasMaxLength(50)
                    .HasColumnName("e性別");

                entity.Property(e => e.E權限).HasColumnName("e權限");

                entity.Property(e => e.E職稱)
                    .HasMaxLength(50)
                    .HasColumnName("e職稱");

                entity.Property(e => e.E身分證號)
                    .HasMaxLength(50)
                    .HasColumnName("e身分證號");

                entity.Property(e => e.E離職日期)
                    .HasColumnType("date")
                    .HasColumnName("e離職日期");

                entity.Property(e => e.E電話)
                    .HasMaxLength(50)
                    .HasColumnName("e電話");
            });

            modelBuilder.Entity<TFamilyMember>(entity =>
            {
                entity.HasKey(e => e.FamId)
                    .HasName("PK_家屬資料表");

                entity.ToTable("tFamilyMembers");

                entity.Property(e => e.FamId).HasColumnName("famId");

                entity.Property(e => e.Fam住址)
                    .HasMaxLength(20)
                    .HasColumnName("fam住址");

                entity.Property(e => e.Fam備註)
                    .HasMaxLength(50)
                    .HasColumnName("fam備註");

                entity.Property(e => e.Fam姓名)
                    .HasMaxLength(10)
                    .HasColumnName("fam姓名");

                entity.Property(e => e.Fam聯絡方式)
                    .HasMaxLength(15)
                    .HasColumnName("fam聯絡方式");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany(p => p.TFamilyMembers)
                    .HasForeignKey(d => d.PId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tFamilyMembers_tPatientInfo");
            });

            modelBuilder.Entity<TNursingRecord>(entity =>
            {
                entity.HasKey(e => e.NId)
                    .HasName("PK_nursingRecord");

                entity.ToTable("tNursingRecord");

                entity.Property(e => e.NId).HasColumnName("nId");

                entity.Property(e => e.EId).HasColumnName("eId");

                entity.Property(e => e.N三管)
                    .HasMaxLength(50)
                    .HasColumnName("n三管");

                entity.Property(e => e.N修改時間)
                    .HasMaxLength(50)
                    .HasColumnName("n修改時間");

                entity.Property(e => e.N傷口)
                    .HasMaxLength(200)
                    .HasColumnName("n傷口");

                entity.Property(e => e.N其他)
                    .HasMaxLength(200)
                    .HasColumnName("n其他");

                entity.Property(e => e.N呼吸)
                    .HasMaxLength(50)
                    .HasColumnName("n呼吸");

                entity.Property(e => e.N收縮壓)
                    .HasMaxLength(50)
                    .HasColumnName("n收縮壓");

                entity.Property(e => e.N紀錄時間)
                    .HasMaxLength(50)
                    .HasColumnName("n紀錄時間");

                entity.Property(e => e.N脈搏)
                    .HasMaxLength(50)
                    .HasColumnName("n脈搏");

                entity.Property(e => e.N舒張壓)
                    .HasMaxLength(50)
                    .HasColumnName("n舒張壓");

                entity.Property(e => e.N體溫)
                    .HasMaxLength(50)
                    .HasColumnName("n體溫");

                entity.Property(e => e.OId).HasColumnName("oId");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.HasOne(d => d.EIdNavigation)
                    .WithMany(p => p.TNursingRecords)
                    .HasForeignKey(d => d.EId)
                    .HasConstraintName("FK_tNursingRecord_tEmployee");

                entity.HasOne(d => d.OIdNavigation)
                    .WithMany(p => p.TNursingRecords)
                    .HasForeignKey(d => d.OId)
                    .HasConstraintName("FK_tNursingRecord_tOffService");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany(p => p.TNursingRecords)
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("FK_tNursingRecord_tPatientInfo");
            });

            modelBuilder.Entity<TOffService>(entity =>
            {
                entity.HasKey(e => e.OId)
                    .HasName("PK_offService");

                entity.ToTable("tOffService");

                entity.Property(e => e.OId).HasColumnName("oId");

                entity.Property(e => e.EId).HasColumnName("eId");

                entity.Property(e => e.O回診日期)
                    .HasMaxLength(50)
                    .HasColumnName("o回診日期");

                entity.Property(e => e.O就診日期)
                    .HasMaxLength(50)
                    .HasColumnName("o就診日期");

                entity.Property(e => e.O建立)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("o建立");

                entity.Property(e => e.O指示與用藥)
                    .HasMaxLength(200)
                    .HasColumnName("o指示與用藥");

                entity.Property(e => e.O更新)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("o更新");

                entity.Property(e => e.O醫師診斷)
                    .HasMaxLength(500)
                    .HasColumnName("o醫師診斷");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.HasOne(d => d.EIdNavigation)
                    .WithMany(p => p.TOffServices)
                    .HasForeignKey(d => d.EId)
                    .HasConstraintName("FK_tOffService_tEmployee");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany(p => p.TOffServices)
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("FK_tOffService_tPatientInfo");
            });

            modelBuilder.Entity<TOrder>(entity =>
            {
                entity.HasKey(e => e.M進貨編號);

                entity.ToTable("tOrder");

                entity.Property(e => e.M進貨編號).HasColumnName("m進貨編號");

                entity.Property(e => e.EId).HasColumnName("eId");

                entity.Property(e => e.M價錢)
                    .HasColumnType("money")
                    .HasColumnName("m價錢");

                entity.Property(e => e.M到貨日期)
                    .HasColumnType("datetime")
                    .HasColumnName("m到貨日期");

                entity.Property(e => e.M小計)
                    .HasColumnType("money")
                    .HasColumnName("m小計");

                entity.Property(e => e.M庫存數量).HasColumnName("m庫存數量");

                entity.Property(e => e.M衛材編號).HasColumnName("m衛材編號");

                entity.Property(e => e.M訂購數量).HasColumnName("m訂購數量");

                entity.Property(e => e.M訂購日期)
                    .HasColumnType("datetime")
                    .HasColumnName("m訂購日期");

                entity.Property(e => e.M訂購狀態).HasColumnName("m訂購狀態");

                entity.HasOne(d => d.EIdNavigation)
                    .WithMany(p => p.TOrders)
                    .HasForeignKey(d => d.EId)
                    .HasConstraintName("FK_tOrder_tEmployee");
            });

            modelBuilder.Entity<TPatientInfo>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK_patientInfo");

                entity.ToTable("tPatientInfo");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.Property(e => e.EId).HasColumnName("eId");

                entity.Property(e => e.P主訴)
                    .HasMaxLength(500)
                    .HasColumnName("p主訴");

                entity.Property(e => e.P出生日期)
                    .HasMaxLength(50)
                    .HasColumnName("p出生日期");

                entity.Property(e => e.P地址)
                    .HasMaxLength(80)
                    .HasColumnName("p地址");

                entity.Property(e => e.P姓名)
                    .HasMaxLength(50)
                    .HasColumnName("p姓名");

                entity.Property(e => e.P建立)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("p建立");

                entity.Property(e => e.P性別)
                    .HasMaxLength(50)
                    .HasColumnName("p性別");

                entity.Property(e => e.P更新)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("p更新");

                entity.Property(e => e.P照片)
                    .HasMaxLength(50)
                    .HasColumnName("p照片");

                entity.Property(e => e.P編號)
                    .HasMaxLength(50)
                    .HasColumnName("p編號");

                entity.Property(e => e.P聯絡人)
                    .HasMaxLength(50)
                    .HasColumnName("p聯絡人");

                entity.Property(e => e.P聯絡電話)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("p聯絡電話");

                entity.Property(e => e.P身分證字號)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("p身分證字號");

                entity.Property(e => e.P醫師診斷)
                    .HasMaxLength(500)
                    .HasColumnName("p醫師診斷");

                entity.Property(e => e.P電話2)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("p電話2");

                entity.Property(e => e.P餐點)
                    .HasMaxLength(50)
                    .HasColumnName("p餐點");

                entity.Property(e => e.家族病史).HasMaxLength(500);

                entity.Property(e => e.指示與用藥).HasMaxLength(500);

                entity.Property(e => e.檢查).HasMaxLength(500);

                entity.Property(e => e.現在病史).HasMaxLength(500);

                entity.Property(e => e.過去病史).HasMaxLength(500);

                entity.HasOne(d => d.EIdNavigation)
                    .WithMany(p => p.TPatientInfos)
                    .HasForeignKey(d => d.EId)
                    .HasConstraintName("FK_tPatientInfo_tEmployee");
            });

            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.HasKey(e => e.M衛材編號);

                entity.ToTable("tProduct");

                entity.Property(e => e.M衛材編號).HasColumnName("m衛材編號");

                entity.Property(e => e.M單位)
                    .HasMaxLength(10)
                    .HasColumnName("m單位");

                entity.Property(e => e.M單價)
                    .HasColumnType("money")
                    .HasColumnName("m單價");

                entity.Property(e => e.M安全庫存數).HasColumnName("m安全庫存數");

                entity.Property(e => e.M庫存數量).HasColumnName("m庫存數量");

                entity.Property(e => e.M衛材名稱)
                    .HasMaxLength(100)
                    .HasColumnName("m衛材名稱");

                entity.Property(e => e.M訂購狀態).HasColumnName("m訂購狀態");
            });

            modelBuilder.Entity<TRoombed>(entity =>
            {
                entity.HasKey(e => e.RbId)
                    .HasName("PK_tRoom");

                entity.ToTable("tRoombed");

                entity.Property(e => e.RbId).HasColumnName("rbId");

                entity.Property(e => e.Rb床號)
                    .HasMaxLength(50)
                    .HasColumnName("rb床號");

                entity.Property(e => e.Rb房型)
                    .HasMaxLength(50)
                    .HasColumnName("rb房型");

                entity.Property(e => e.Rb空床)
                    .HasMaxLength(50)
                    .HasColumnName("rb空床");
            });

            modelBuilder.Entity<TShift>(entity =>
            {
                entity.HasKey(e => e.SId);

                entity.ToTable("tShift");

                entity.Property(e => e.SId).HasColumnName("sId");

                entity.Property(e => e.EId).HasColumnName("eId");

                entity.Property(e => e.S中班)
                    .HasMaxLength(50)
                    .HasColumnName("s中班");

                entity.Property(e => e.S休假)
                    .HasMaxLength(50)
                    .HasColumnName("s休假");

                entity.Property(e => e.S備註)
                    .HasMaxLength(50)
                    .HasColumnName("s備註");

                entity.Property(e => e.S日期)
                    .HasColumnType("date")
                    .HasColumnName("s日期");

                entity.Property(e => e.S早班)
                    .HasMaxLength(50)
                    .HasColumnName("s早班");

                entity.Property(e => e.S晚班)
                    .HasMaxLength(50)
                    .HasColumnName("s晚班");

                entity.HasOne(d => d.EIdNavigation)
                    .WithMany(p => p.TShifts)
                    .HasForeignKey(d => d.EId)
                    .HasConstraintName("FK_tShift_tEmployee");
            });

            modelBuilder.Entity<TTake>(entity =>
            {
                entity.HasKey(e => e.M領取編號);

                entity.ToTable("tTake");

                entity.Property(e => e.M領取編號).HasColumnName("m領取編號");

                entity.Property(e => e.EId).HasColumnName("eId");

                entity.Property(e => e.M庫存數量).HasColumnName("m庫存數量");

                entity.Property(e => e.M用途)
                    .HasMaxLength(100)
                    .HasColumnName("m用途");

                entity.Property(e => e.M衛材編號).HasColumnName("m衛材編號");

                entity.Property(e => e.M領取數量).HasColumnName("m領取數量");

                entity.Property(e => e.M領取時間)
                    .HasColumnType("datetime")
                    .HasColumnName("m領取時間");

                entity.HasOne(d => d.EIdNavigation)
                    .WithMany(p => p.TTakes)
                    .HasForeignKey(d => d.EId)
                    .HasConstraintName("FK_tTake_tEmployee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
