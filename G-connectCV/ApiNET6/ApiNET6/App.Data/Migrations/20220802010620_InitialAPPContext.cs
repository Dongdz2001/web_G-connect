using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class InitialAPPContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "qtht_nguoi_dung",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tai_khoan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    mat_khau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    salt_code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    trang_thai = table.Column<int>(type: "int", nullable: false),
                    super_admin = table.Column<bool>(type: "bit", nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    so_dien_thoai = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    anh_dai_dien_url = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    is_dau_moi = table.Column<bool>(type: "bit", nullable: true),
                    chuc_vu_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    file_dinh_kem_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    nguoi_tao_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nguoi_chinh_sua_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_chinh_sua = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qtht_nguoi_dung", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "qtht_cau_hinh_ma",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gia_tri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nguoi_tao_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nguoi_chinh_sua_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_chinh_sua = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qtht_cau_hinh_ma", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "qtht_chuc_vu",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ma = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_ta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nguoi_tao_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nguoi_chinh_sua_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_chinh_sua = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qtht_chuc_vu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "qtht_dieu_huong",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ma = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duong_dan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    icon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    so_thu_tu = table.Column<int>(type: "int", nullable: true),
                    stt_order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_quan_tri = table.Column<bool>(type: "bit", nullable: true),
                    mo_ta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cap_dieu_huong = table.Column<int>(type: "int", nullable: false),
                    muc_luc = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    dieu_huong_cap_tren_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    super_admin = table.Column<bool>(type: "bit", nullable: false),
                    is_router = table.Column<bool>(type: "bit", nullable: false),
                    nguoi_tao_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nguoi_chinh_sua_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_chinh_sua = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qtht_dieu_huong", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "qtht_file_dinh_kem",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    duong_dan = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noi_dung_tep = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    noi_dung_tep_pdf = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    file_finish = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    nguoi_tao_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nguoi_chinh_sua_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_chinh_sua = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qtht_file_dinh_kem", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "qtht_google_config",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    refresh_token = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    nguoi_tao_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nguoi_chinh_sua_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_chinh_sua = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qtht_google_config", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "qtht_nhat_ky_he_thong",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ban_ghi_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    nguoi_thuc_hien_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    hanh_dong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noi_dung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duong_dan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: true),
                    nguoi_tao_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nguoi_chinh_sua_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_chinh_sua = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qtht_nhat_ky_he_thong", x => x.id);
                    table.ForeignKey(
                        name: "FK_qtht_nhat_ky_he_thong_qtht_nguoi_dung_nguoi_thuc_hien_id",
                        column: x => x.nguoi_thuc_hien_id,
                        principalTable: "qtht_nguoi_dung",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "qtht_nhat_ky_he_thong_loai",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    hanh_dong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ten_hanh_dong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nguoi_tao_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nguoi_chinh_sua_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_chinh_sua = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qtht_nhat_ky_he_thong_loai", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "qtht_nhom_nguoi_dung",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ma = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nguoi_tao_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nguoi_chinh_sua_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ngay_chinh_sua = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qtht_nhom_nguoi_dung", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "qtht_nguoi_dung_2_nhom_nguoi_dung",
                columns: table => new
                {
                    nguoi_dung_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nhom_nguoi_dung_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qtht_nguoi_dung_2_nhom_nguoi_dung", x => new { x.nguoi_dung_id, x.nhom_nguoi_dung_id });
                    table.ForeignKey(
                        name: "FK_qtht_nguoi_dung_2_nhom_nguoi_dung_qtht_nguoi_dung_nguoi_dung_id",
                        column: x => x.nguoi_dung_id,
                        principalTable: "qtht_nguoi_dung",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qtht_nguoi_dung_2_nhom_nguoi_dung_qtht_nhom_nguoi_dung_nhom_nguoi_dung_id",
                        column: x => x.nhom_nguoi_dung_id,
                        principalTable: "qtht_nhom_nguoi_dung",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qtht_nhom_nguoi_dung_2_dieu_huong",
                columns: table => new
                {
                    nhom_nguoi_dung_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dieu_huong_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qtht_nhom_nguoi_dung_2_dieu_huong", x => new { x.nhom_nguoi_dung_id, x.dieu_huong_id });
                    table.ForeignKey(
                        name: "FK_qtht_nhom_nguoi_dung_2_dieu_huong_qtht_dieu_huong_dieu_huong_id",
                        column: x => x.dieu_huong_id,
                        principalTable: "qtht_dieu_huong",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qtht_nhom_nguoi_dung_2_dieu_huong_qtht_nhom_nguoi_dung_nhom_nguoi_dung_id",
                        column: x => x.nhom_nguoi_dung_id,
                        principalTable: "qtht_nhom_nguoi_dung",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_qtht_cau_hinh_ma_nguoi_chinh_sua_id",
                table: "qtht_cau_hinh_ma",
                column: "nguoi_chinh_sua_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_cau_hinh_ma_nguoi_tao_id",
                table: "qtht_cau_hinh_ma",
                column: "nguoi_tao_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_chuc_vu_nguoi_chinh_sua_id",
                table: "qtht_chuc_vu",
                column: "nguoi_chinh_sua_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_chuc_vu_nguoi_tao_id",
                table: "qtht_chuc_vu",
                column: "nguoi_tao_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_dieu_huong_dieu_huong_cap_tren_id",
                table: "qtht_dieu_huong",
                column: "dieu_huong_cap_tren_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_dieu_huong_nguoi_chinh_sua_id",
                table: "qtht_dieu_huong",
                column: "nguoi_chinh_sua_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_dieu_huong_nguoi_tao_id",
                table: "qtht_dieu_huong",
                column: "nguoi_tao_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_file_dinh_kem_nguoi_chinh_sua_id",
                table: "qtht_file_dinh_kem",
                column: "nguoi_chinh_sua_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_file_dinh_kem_nguoi_tao_id",
                table: "qtht_file_dinh_kem",
                column: "nguoi_tao_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_google_config_nguoi_chinh_sua_id",
                table: "qtht_google_config",
                column: "nguoi_chinh_sua_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_google_config_nguoi_tao_id",
                table: "qtht_google_config",
                column: "nguoi_tao_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nguoi_dung_chuc_vu_id",
                table: "qtht_nguoi_dung",
                column: "chuc_vu_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nguoi_dung_file_dinh_kem_id",
                table: "qtht_nguoi_dung",
                column: "file_dinh_kem_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nguoi_dung_nguoi_chinh_sua_id",
                table: "qtht_nguoi_dung",
                column: "nguoi_chinh_sua_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nguoi_dung_nguoi_tao_id",
                table: "qtht_nguoi_dung",
                column: "nguoi_tao_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nguoi_dung_2_nhom_nguoi_dung_nhom_nguoi_dung_id",
                table: "qtht_nguoi_dung_2_nhom_nguoi_dung",
                column: "nhom_nguoi_dung_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nhat_ky_he_thong_nguoi_chinh_sua_id",
                table: "qtht_nhat_ky_he_thong",
                column: "nguoi_chinh_sua_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nhat_ky_he_thong_nguoi_tao_id",
                table: "qtht_nhat_ky_he_thong",
                column: "nguoi_tao_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nhat_ky_he_thong_nguoi_thuc_hien_id",
                table: "qtht_nhat_ky_he_thong",
                column: "nguoi_thuc_hien_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nhat_ky_he_thong_loai_nguoi_chinh_sua_id",
                table: "qtht_nhat_ky_he_thong_loai",
                column: "nguoi_chinh_sua_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nhat_ky_he_thong_loai_nguoi_tao_id",
                table: "qtht_nhat_ky_he_thong_loai",
                column: "nguoi_tao_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nhom_nguoi_dung_nguoi_chinh_sua_id",
                table: "qtht_nhom_nguoi_dung",
                column: "nguoi_chinh_sua_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nhom_nguoi_dung_nguoi_tao_id",
                table: "qtht_nhom_nguoi_dung",
                column: "nguoi_tao_id");

            migrationBuilder.CreateIndex(
                name: "IX_qtht_nhom_nguoi_dung_2_dieu_huong_dieu_huong_id",
                table: "qtht_nhom_nguoi_dung_2_dieu_huong",
                column: "dieu_huong_id");

            migrationBuilder.AddForeignKey(
                name: "FK_qtht_nguoi_dung_qtht_chuc_vu_chuc_vu_id",
                table: "qtht_nguoi_dung",
                column: "chuc_vu_id",
                principalTable: "qtht_chuc_vu",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_qtht_nguoi_dung_qtht_file_dinh_kem_file_dinh_kem_id",
                table: "qtht_nguoi_dung",
                column: "file_dinh_kem_id",
                principalTable: "qtht_file_dinh_kem",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_qtht_chuc_vu_qtht_nguoi_dung_nguoi_chinh_sua_id",
                table: "qtht_chuc_vu");

            migrationBuilder.DropForeignKey(
                name: "FK_qtht_chuc_vu_qtht_nguoi_dung_nguoi_tao_id",
                table: "qtht_chuc_vu");

            migrationBuilder.DropForeignKey(
                name: "FK_qtht_file_dinh_kem_qtht_nguoi_dung_nguoi_chinh_sua_id",
                table: "qtht_file_dinh_kem");

            migrationBuilder.DropForeignKey(
                name: "FK_qtht_file_dinh_kem_qtht_nguoi_dung_nguoi_tao_id",
                table: "qtht_file_dinh_kem");

            migrationBuilder.DropTable(
                name: "qtht_cau_hinh_ma");

            migrationBuilder.DropTable(
                name: "qtht_google_config");

            migrationBuilder.DropTable(
                name: "qtht_nguoi_dung_2_nhom_nguoi_dung");

            migrationBuilder.DropTable(
                name: "qtht_nhat_ky_he_thong");

            migrationBuilder.DropTable(
                name: "qtht_nhat_ky_he_thong_loai");

            migrationBuilder.DropTable(
                name: "qtht_nhom_nguoi_dung_2_dieu_huong");

            migrationBuilder.DropTable(
                name: "qtht_dieu_huong");

            migrationBuilder.DropTable(
                name: "qtht_nhom_nguoi_dung");

            migrationBuilder.DropTable(
                name: "qtht_nguoi_dung");

            migrationBuilder.DropTable(
                name: "qtht_chuc_vu");

            migrationBuilder.DropTable(
                name: "qtht_file_dinh_kem");
        }
    }
}
