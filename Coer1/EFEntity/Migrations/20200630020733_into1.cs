using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFEntity.Migrations
{
    public partial class into1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "config_file_first_kind",
                columns: table => new
                {
                    ffk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    first_kind_name = table.Column<string>(maxLength: 60, nullable: true),
                    first_kind_salary_id = table.Column<string>(nullable: true),
                    first_kind_sale_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_file_first_kind", x => x.ffk_id);
                });

            migrationBuilder.CreateTable(
                name: "config_file_second_kind",
                columns: table => new
                {
                    fsk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    first_kind_name = table.Column<string>(maxLength: 60, nullable: true),
                    second_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    second_kind_name = table.Column<string>(maxLength: 60, nullable: true),
                    second_salary_id = table.Column<string>(nullable: true),
                    second_sale_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_file_second_kind", x => x.fsk_id);
                });

            migrationBuilder.CreateTable(
                name: "config_file_third_kind",
                columns: table => new
                {
                    ftk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    first_kind_name = table.Column<string>(maxLength: 60, nullable: true),
                    second_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    second_kind_name = table.Column<string>(maxLength: 60, nullable: true),
                    third_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    third_kind_name = table.Column<string>(maxLength: 60, nullable: true),
                    third_kind_sale_id = table.Column<string>(nullable: true),
                    third_kind_is_retail = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_file_third_kind", x => x.ftk_id);
                });

            migrationBuilder.CreateTable(
                name: "config_major",
                columns: table => new
                {
                    mak_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    major_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    major_kind_name = table.Column<string>(maxLength: 60, nullable: true),
                    major_id = table.Column<string>(maxLength: 2, nullable: true),
                    major_name = table.Column<string>(maxLength: 60, nullable: true),
                    test_amount = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_major", x => x.mak_id);
                });

            migrationBuilder.CreateTable(
                name: "config_major_kind",
                columns: table => new
                {
                    mfk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    major_kind_id = table.Column<string>(maxLength: 2, nullable: true),
                    major_kind_name = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_major_kind", x => x.mfk_id);
                });

            migrationBuilder.CreateTable(
                name: "config_primary_key",
                columns: table => new
                {
                    prk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    primary_key_table = table.Column<string>(nullable: true),
                    primary_key = table.Column<string>(nullable: true),
                    key_name = table.Column<string>(nullable: true),
                    primary_key_status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_primary_key", x => x.prk_id);
                });

            migrationBuilder.CreateTable(
                name: "config_public_char",
                columns: table => new
                {
                    pbc_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attribute_kind = table.Column<string>(maxLength: 60, nullable: true),
                    attribute_name = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_public_char", x => x.pbc_id);
                });

            migrationBuilder.CreateTable(
                name: "config_question_first_kind",
                columns: table => new
                {
                    qfk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_kind_id = table.Column<string>(nullable: true),
                    first_kind_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_question_first_kind", x => x.qfk_id);
                });

            migrationBuilder.CreateTable(
                name: "config_question_second_kind",
                columns: table => new
                {
                    qsk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_kind_id = table.Column<string>(nullable: true),
                    first_kind_name = table.Column<string>(nullable: true),
                    second_kind_id = table.Column<string>(nullable: true),
                    second_kind_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_question_second_kind", x => x.qsk_id);
                });

            migrationBuilder.CreateTable(
                name: "engage_answer",
                columns: table => new
                {
                    ans_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    answer_number = table.Column<string>(nullable: true),
                    exam_number = table.Column<string>(nullable: true),
                    resume_id = table.Column<int>(nullable: false),
                    interview_id = table.Column<int>(nullable: false),
                    human_name = table.Column<string>(nullable: true),
                    human_idcard = table.Column<string>(nullable: true),
                    major_kind_id = table.Column<string>(nullable: true),
                    major_kind_name = table.Column<string>(nullable: true),
                    major_id = table.Column<string>(nullable: true),
                    major_name = table.Column<string>(nullable: true),
                    test_time = table.Column<DateTime>(nullable: false),
                    use_time = table.Column<string>(nullable: true),
                    total_point = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engage_answer", x => x.ans_id);
                });

            migrationBuilder.CreateTable(
                name: "engage_answer_details",
                columns: table => new
                {
                    and_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    answer_number = table.Column<string>(nullable: true),
                    subject_id = table.Column<int>(nullable: false),
                    answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engage_answer_details", x => x.and_id);
                });

            migrationBuilder.CreateTable(
                name: "engage_exam",
                columns: table => new
                {
                    exa_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exam_number = table.Column<string>(nullable: true),
                    major_kind_id = table.Column<string>(nullable: true),
                    major_kind_name = table.Column<string>(nullable: true),
                    major_id = table.Column<string>(nullable: true),
                    major_name = table.Column<string>(nullable: true),
                    register = table.Column<string>(nullable: true),
                    regist_time = table.Column<DateTime>(nullable: false),
                    limite_time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engage_exam", x => x.exa_id);
                });

            migrationBuilder.CreateTable(
                name: "engage_exam_details",
                columns: table => new
                {
                    exd_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exam_number = table.Column<string>(nullable: true),
                    first_kind_id = table.Column<string>(nullable: true),
                    first_kind_name = table.Column<string>(nullable: true),
                    second_kind_id = table.Column<string>(nullable: true),
                    second_kind_name = table.Column<string>(nullable: true),
                    question_amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engage_exam_details", x => x.exd_id);
                });

            migrationBuilder.CreateTable(
                name: "engage_interview",
                columns: table => new
                {
                    ein_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    human_name = table.Column<string>(nullable: true),
                    interview_amount = table.Column<int>(nullable: false),
                    human_major_kind_id = table.Column<string>(nullable: true),
                    human_major_kind_name = table.Column<string>(nullable: true),
                    human_major_id = table.Column<string>(nullable: true),
                    human_major_name = table.Column<string>(nullable: true),
                    image_degree = table.Column<string>(nullable: true),
                    native_language_degree = table.Column<string>(nullable: true),
                    foreign_language_degree = table.Column<int>(nullable: false),
                    response_speed_degree = table.Column<string>(nullable: true),
                    EQ_degree = table.Column<string>(nullable: true),
                    IQ_degree = table.Column<string>(nullable: true),
                    multi_quality_degree = table.Column<string>(nullable: true),
                    register = table.Column<string>(nullable: true),
                    checker = table.Column<string>(nullable: true),
                    registe_time = table.Column<DateTime>(nullable: false),
                    check_time = table.Column<DateTime>(nullable: false),
                    resume_id = table.Column<int>(nullable: false),
                    result = table.Column<string>(nullable: true),
                    interview_comment = table.Column<string>(nullable: true),
                    check_comment = table.Column<string>(nullable: true),
                    interview_status = table.Column<int>(nullable: false),
                    check_status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engage_interview", x => x.ein_id);
                });

            migrationBuilder.CreateTable(
                name: "engage_major_release",
                columns: table => new
                {
                    mre_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_kind_id = table.Column<string>(nullable: true),
                    first_kind_name = table.Column<string>(nullable: true),
                    second_kind_id = table.Column<string>(nullable: true),
                    second_kind_name = table.Column<string>(nullable: true),
                    third_kind_id = table.Column<string>(nullable: true),
                    third_kind_name = table.Column<string>(nullable: true),
                    major_kind_id = table.Column<string>(nullable: true),
                    major_kind_name = table.Column<string>(nullable: true),
                    major_id = table.Column<string>(nullable: true),
                    major_name = table.Column<string>(nullable: true),
                    human_amount = table.Column<int>(nullable: false),
                    engage_type = table.Column<string>(nullable: true),
                    deadline = table.Column<DateTime>(nullable: false),
                    register = table.Column<string>(nullable: true),
                    changer = table.Column<string>(nullable: true),
                    regist_time = table.Column<DateTime>(nullable: false),
                    change_time = table.Column<DateTime>(nullable: false),
                    major_describe = table.Column<string>(nullable: true),
                    engage_required = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engage_major_release", x => x.mre_id);
                });

            migrationBuilder.CreateTable(
                name: "engage_resume",
                columns: table => new
                {
                    res_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    human_name = table.Column<string>(nullable: true),
                    engage_type = table.Column<string>(nullable: true),
                    human_address = table.Column<string>(nullable: true),
                    human_postcode = table.Column<string>(nullable: true),
                    human_major_kind_id = table.Column<string>(nullable: true),
                    human_major_kind_name = table.Column<string>(nullable: true),
                    human_major_id = table.Column<string>(nullable: true),
                    human_major_name = table.Column<string>(nullable: true),
                    human_telephone = table.Column<string>(nullable: true),
                    human_homephone = table.Column<string>(nullable: true),
                    human_mobilephone = table.Column<string>(nullable: true),
                    human_email = table.Column<string>(nullable: true),
                    human_hobby = table.Column<string>(nullable: true),
                    human_specility = table.Column<string>(nullable: true),
                    human_sex = table.Column<string>(nullable: true),
                    human_religion = table.Column<string>(nullable: true),
                    human_party = table.Column<string>(nullable: true),
                    human_nationality = table.Column<string>(nullable: true),
                    human_race = table.Column<string>(nullable: true),
                    human_birthday = table.Column<DateTime>(nullable: false),
                    human_age = table.Column<int>(nullable: false),
                    human_educated_degree = table.Column<string>(nullable: true),
                    human_educated_years = table.Column<int>(nullable: false),
                    human_educated_major = table.Column<string>(nullable: true),
                    human_college = table.Column<string>(nullable: true),
                    human_idcard = table.Column<string>(nullable: true),
                    human_birthplace = table.Column<string>(nullable: true),
                    demand_salary_standard = table.Column<double>(nullable: false),
                    human_history_records = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    recomandation = table.Column<string>(nullable: true),
                    human_picture = table.Column<string>(nullable: true),
                    attachment_name = table.Column<string>(nullable: true),
                    check_status = table.Column<int>(nullable: false),
                    register = table.Column<string>(nullable: true),
                    regist_time = table.Column<DateTime>(nullable: false),
                    checker = table.Column<string>(nullable: true),
                    check_time = table.Column<DateTime>(nullable: false),
                    interview_status = table.Column<int>(nullable: false),
                    total_points = table.Column<float>(nullable: false),
                    test_amount = table.Column<int>(nullable: false),
                    test_checker = table.Column<string>(nullable: true),
                    test_check_time = table.Column<DateTime>(nullable: false),
                    pass_register = table.Column<string>(nullable: true),
                    pass_regist_time = table.Column<DateTime>(nullable: false),
                    pass_checker = table.Column<string>(nullable: true),
                    pass_check_time = table.Column<DateTime>(nullable: false),
                    pass_check_status = table.Column<int>(nullable: false),
                    pass_checkComment = table.Column<string>(nullable: true),
                    pass_passComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engage_resume", x => x.res_id);
                });

            migrationBuilder.CreateTable(
                name: "engage_subjects",
                columns: table => new
                {
                    sub_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_kind_id = table.Column<string>(nullable: true),
                    first_kind_name = table.Column<string>(nullable: true),
                    second_kind_id = table.Column<string>(nullable: true),
                    second_kind_name = table.Column<string>(nullable: true),
                    register = table.Column<string>(nullable: true),
                    regist_time = table.Column<DateTime>(nullable: false),
                    derivation = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    key_a = table.Column<string>(nullable: true),
                    key_b = table.Column<string>(nullable: true),
                    key_c = table.Column<string>(nullable: true),
                    key_d = table.Column<string>(nullable: true),
                    key_e = table.Column<string>(nullable: true),
                    correct_key = table.Column<string>(nullable: true),
                    changer = table.Column<string>(nullable: true),
                    change_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engage_subjects", x => x.sub_id);
                });

            migrationBuilder.CreateTable(
                name: "human_file",
                columns: table => new
                {
                    huf_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    human_id = table.Column<string>(nullable: true),
                    first_kind_id = table.Column<string>(nullable: true),
                    first_kind_name = table.Column<string>(nullable: true),
                    second_kind_id = table.Column<string>(nullable: true),
                    second_kind_name = table.Column<string>(nullable: true),
                    third_kind_id = table.Column<string>(nullable: true),
                    third_kind_name = table.Column<string>(nullable: true),
                    human_name = table.Column<string>(nullable: true),
                    human_address = table.Column<string>(nullable: true),
                    human_postcode = table.Column<string>(nullable: true),
                    human_pro_designation = table.Column<string>(nullable: true),
                    human_major_kind_id = table.Column<string>(nullable: true),
                    human_major_kind_name = table.Column<string>(nullable: true),
                    human_major_id = table.Column<string>(nullable: true),
                    hunma_major_name = table.Column<string>(nullable: true),
                    human_telephone = table.Column<string>(nullable: true),
                    human_mobilephone = table.Column<string>(nullable: true),
                    human_bank = table.Column<string>(nullable: true),
                    human_account = table.Column<string>(nullable: true),
                    human_qq = table.Column<string>(nullable: true),
                    human_email = table.Column<string>(nullable: true),
                    human_hobby = table.Column<string>(nullable: true),
                    human_speciality = table.Column<string>(nullable: true),
                    human_sex = table.Column<string>(nullable: true),
                    human_religion = table.Column<string>(nullable: true),
                    human_party = table.Column<string>(nullable: true),
                    human_nationality = table.Column<string>(nullable: true),
                    human_race = table.Column<string>(nullable: true),
                    human_birthday = table.Column<DateTime>(nullable: false),
                    human_birthplace = table.Column<string>(nullable: true),
                    vhuman_age = table.Column<int>(nullable: false),
                    human_educated_degree = table.Column<string>(nullable: true),
                    human_educated_years = table.Column<int>(nullable: false),
                    human_educated_major = table.Column<string>(nullable: true),
                    human_society_security_id = table.Column<string>(nullable: true),
                    human_id_card = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    salary_standard_id = table.Column<string>(nullable: true),
                    salary_standard_name = table.Column<string>(nullable: true),
                    salary_sum = table.Column<double>(nullable: false),
                    demand_salaray_sum = table.Column<double>(nullable: false),
                    paid_salary_sum = table.Column<double>(nullable: false),
                    major_change_amount = table.Column<int>(nullable: false),
                    bonus_amount = table.Column<int>(nullable: false),
                    training_amount = table.Column<int>(nullable: false),
                    file_chang_amount = table.Column<int>(nullable: false),
                    human_histroy_records = table.Column<string>(nullable: true),
                    human_family_membership = table.Column<string>(nullable: true),
                    human_picture = table.Column<string>(nullable: true),
                    attachment_name = table.Column<string>(nullable: true),
                    check_status = table.Column<int>(nullable: false),
                    register = table.Column<string>(nullable: true),
                    checker = table.Column<string>(nullable: true),
                    changer = table.Column<string>(nullable: true),
                    regist_time = table.Column<DateTime>(nullable: false),
                    check_time = table.Column<DateTime>(nullable: false),
                    change_time = table.Column<DateTime>(nullable: false),
                    lastly_change_time = table.Column<DateTime>(nullable: false),
                    delete_time = table.Column<DateTime>(nullable: false),
                    recovery_time = table.Column<DateTime>(nullable: false),
                    human_file_status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_human_file", x => x.huf_id);
                });

            migrationBuilder.CreateTable(
                name: "human_file_dig",
                columns: table => new
                {
                    hfd_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    human_id = table.Column<string>(nullable: true),
                    first_kind_id = table.Column<string>(nullable: true),
                    first_kind_name = table.Column<string>(nullable: true),
                    second_kind_id = table.Column<string>(nullable: true),
                    second_kind_name = table.Column<string>(nullable: true),
                    third_kind_id = table.Column<string>(nullable: true),
                    third_kind_name = table.Column<string>(nullable: true),
                    human_name = table.Column<string>(nullable: true),
                    human_address = table.Column<string>(nullable: true),
                    human_postcode = table.Column<string>(nullable: true),
                    human_pro_designation = table.Column<string>(nullable: true),
                    human_major_kind_id = table.Column<string>(nullable: true),
                    human_major_kind_name = table.Column<string>(nullable: true),
                    human_major_id = table.Column<string>(nullable: true),
                    hunma_major_name = table.Column<string>(nullable: true),
                    human_telephone = table.Column<string>(nullable: true),
                    human_mobilephone = table.Column<string>(nullable: true),
                    human_bank = table.Column<string>(nullable: true),
                    human_account = table.Column<string>(nullable: true),
                    human_qq = table.Column<string>(nullable: true),
                    human_email = table.Column<string>(nullable: true),
                    human_hobby = table.Column<string>(nullable: true),
                    human_speciality = table.Column<string>(nullable: true),
                    human_sex = table.Column<string>(nullable: true),
                    human_religion = table.Column<string>(nullable: true),
                    human_party = table.Column<string>(nullable: true),
                    human_nationality = table.Column<string>(nullable: true),
                    human_race = table.Column<string>(nullable: true),
                    human_birthday = table.Column<DateTime>(nullable: false),
                    human_birthplace = table.Column<string>(nullable: true),
                    human_age = table.Column<int>(nullable: false),
                    human_educated_degree = table.Column<string>(nullable: true),
                    human_educated_years = table.Column<int>(nullable: false),
                    human_educated_major = table.Column<string>(nullable: true),
                    human_society_security_id = table.Column<string>(nullable: true),
                    human_id_card = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    salary_standard_id = table.Column<string>(nullable: true),
                    salary_standard_name = table.Column<string>(nullable: true),
                    salary_sum = table.Column<double>(nullable: false),
                    demand_salaray_sum = table.Column<double>(nullable: false),
                    paid_salary_sum = table.Column<double>(nullable: false),
                    major_change_amount = table.Column<int>(nullable: false),
                    bonus_amount = table.Column<int>(nullable: false),
                    training_amount = table.Column<int>(nullable: false),
                    file_chang_amount = table.Column<int>(nullable: false),
                    human_histroy_records = table.Column<string>(nullable: true),
                    human_family_membership = table.Column<string>(nullable: true),
                    human_picture = table.Column<string>(nullable: true),
                    attachment_name = table.Column<string>(nullable: true),
                    check_status = table.Column<int>(nullable: false),
                    register = table.Column<string>(nullable: true),
                    checker = table.Column<string>(nullable: true),
                    changer = table.Column<string>(nullable: true),
                    regist_time = table.Column<DateTime>(nullable: false),
                    check_time = table.Column<DateTime>(nullable: false),
                    change_time = table.Column<DateTime>(nullable: false),
                    lastly_change_time = table.Column<DateTime>(nullable: false),
                    delete_time = table.Column<DateTime>(nullable: false),
                    recovery_time = table.Column<DateTime>(nullable: false),
                    human_file_status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_human_file_dig", x => x.hfd_id);
                });

            migrationBuilder.CreateTable(
                name: "major_change",
                columns: table => new
                {
                    mch_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_kind_id = table.Column<string>(nullable: true),
                    first_kind_name = table.Column<string>(nullable: true),
                    second_kind_id = table.Column<string>(nullable: true),
                    second_kind_name = table.Column<string>(nullable: true),
                    third_kind_id = table.Column<string>(nullable: true),
                    third_kind_name = table.Column<string>(nullable: true),
                    major_kind_id = table.Column<string>(nullable: true),
                    major_kind_name = table.Column<string>(nullable: true),
                    major_id = table.Column<string>(nullable: true),
                    major_name = table.Column<string>(nullable: true),
                    new_first_kind_id = table.Column<string>(nullable: true),
                    new_first_kind_name = table.Column<string>(nullable: true),
                    new_second_kind_id = table.Column<string>(nullable: true),
                    new_second_kind_name = table.Column<string>(nullable: true),
                    new_third_kind_id = table.Column<string>(nullable: true),
                    new_third_kind_name = table.Column<string>(nullable: true),
                    new_major_kind_id = table.Column<string>(nullable: true),
                    new_major_kind_name = table.Column<string>(nullable: true),
                    new_major_id = table.Column<string>(nullable: true),
                    new_major_name = table.Column<string>(nullable: true),
                    human_id = table.Column<string>(nullable: true),
                    human_name = table.Column<string>(nullable: true),
                    salary_standard_id = table.Column<string>(nullable: true),
                    salary_standard_name = table.Column<string>(nullable: true),
                    salary_sum = table.Column<double>(nullable: false),
                    new_salary_standard_id = table.Column<string>(nullable: true),
                    new_salary_standard_name = table.Column<string>(nullable: true),
                    new_salary_sum = table.Column<double>(nullable: false),
                    change_reason = table.Column<string>(nullable: true),
                    check_reason = table.Column<string>(nullable: true),
                    check_status = table.Column<int>(nullable: false),
                    register = table.Column<string>(nullable: true),
                    checker = table.Column<string>(nullable: true),
                    regist_time = table.Column<DateTime>(nullable: false),
                    check_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_major_change", x => x.mch_id);
                });

            migrationBuilder.CreateTable(
                name: "salary_grant",
                columns: table => new
                {
                    sgr_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salary_grant_id = table.Column<string>(nullable: true),
                    salary_standard_id = table.Column<string>(nullable: true),
                    first_kind_id = table.Column<string>(nullable: true),
                    first_kind_name = table.Column<string>(nullable: true),
                    second_kind_id = table.Column<string>(nullable: true),
                    second_kind_name = table.Column<string>(nullable: true),
                    third_kind_id = table.Column<string>(nullable: true),
                    third_kind_name = table.Column<string>(nullable: true),
                    human_amount = table.Column<int>(nullable: false),
                    salary_standard_sum = table.Column<double>(nullable: false),
                    salary_paid_sum = table.Column<double>(nullable: false),
                    register = table.Column<string>(nullable: true),
                    regist_time = table.Column<DateTime>(nullable: false),
                    checker = table.Column<string>(nullable: true),
                    check_time = table.Column<DateTime>(nullable: false),
                    check_status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary_grant", x => x.sgr_id);
                });

            migrationBuilder.CreateTable(
                name: "salary_grant_details",
                columns: table => new
                {
                    grd_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salary_grant_id = table.Column<string>(nullable: true),
                    human_id = table.Column<string>(nullable: true),
                    human_name = table.Column<string>(nullable: true),
                    bouns_sum = table.Column<double>(nullable: false),
                    sale_sum = table.Column<double>(nullable: false),
                    deduct_sum = table.Column<double>(nullable: false),
                    salary_standard_sum = table.Column<double>(nullable: false),
                    salary_paid_sum = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary_grant_details", x => x.grd_id);
                });

            migrationBuilder.CreateTable(
                name: "salary_standard",
                columns: table => new
                {
                    ssd_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    standard_id = table.Column<string>(nullable: true),
                    standard_name = table.Column<string>(nullable: true),
                    designer = table.Column<string>(nullable: true),
                    register = table.Column<string>(nullable: true),
                    checker = table.Column<string>(nullable: true),
                    changer = table.Column<string>(nullable: true),
                    regist_time = table.Column<DateTime>(nullable: false),
                    check_time = table.Column<DateTime>(nullable: false),
                    change_time = table.Column<DateTime>(nullable: false),
                    salary_sum = table.Column<double>(nullable: false),
                    check_status = table.Column<int>(nullable: false),
                    change_status = table.Column<int>(nullable: false),
                    check_comment = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary_standard", x => x.ssd_id);
                });

            migrationBuilder.CreateTable(
                name: "salary_standard_details",
                columns: table => new
                {
                    sdt_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    standard_id = table.Column<string>(nullable: true),
                    standard_name = table.Column<string>(nullable: true),
                    item_id = table.Column<int>(nullable: false),
                    item_name = table.Column<string>(nullable: true),
                    salary = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary_standard_details", x => x.sdt_id);
                });

            migrationBuilder.CreateTable(
                name: "Tesc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tesc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "training",
                columns: table => new
                {
                    tra_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    major_kind_id = table.Column<string>(nullable: true),
                    major_kind_name = table.Column<string>(nullable: true),
                    major_id = table.Column<string>(nullable: true),
                    major_name = table.Column<string>(nullable: true),
                    human_id = table.Column<string>(nullable: true),
                    human_name = table.Column<string>(nullable: true),
                    training_item = table.Column<string>(nullable: true),
                    training_time = table.Column<DateTime>(nullable: false),
                    training_hour = table.Column<int>(nullable: false),
                    training_degree = table.Column<string>(nullable: true),
                    register = table.Column<string>(nullable: true),
                    checker = table.Column<string>(nullable: true),
                    regist_time = table.Column<DateTime>(nullable: false),
                    check_time = table.Column<DateTime>(nullable: false),
                    checkstatus = table.Column<int>(nullable: false),
                    remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training", x => x.tra_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(nullable: true),
                    user_true_name = table.Column<string>(nullable: true),
                    user_password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "config_file_first_kind");

            migrationBuilder.DropTable(
                name: "config_file_second_kind");

            migrationBuilder.DropTable(
                name: "config_file_third_kind");

            migrationBuilder.DropTable(
                name: "config_major");

            migrationBuilder.DropTable(
                name: "config_major_kind");

            migrationBuilder.DropTable(
                name: "config_primary_key");

            migrationBuilder.DropTable(
                name: "config_public_char");

            migrationBuilder.DropTable(
                name: "config_question_first_kind");

            migrationBuilder.DropTable(
                name: "config_question_second_kind");

            migrationBuilder.DropTable(
                name: "engage_answer");

            migrationBuilder.DropTable(
                name: "engage_answer_details");

            migrationBuilder.DropTable(
                name: "engage_exam");

            migrationBuilder.DropTable(
                name: "engage_exam_details");

            migrationBuilder.DropTable(
                name: "engage_interview");

            migrationBuilder.DropTable(
                name: "engage_major_release");

            migrationBuilder.DropTable(
                name: "engage_resume");

            migrationBuilder.DropTable(
                name: "engage_subjects");

            migrationBuilder.DropTable(
                name: "human_file");

            migrationBuilder.DropTable(
                name: "human_file_dig");

            migrationBuilder.DropTable(
                name: "major_change");

            migrationBuilder.DropTable(
                name: "salary_grant");

            migrationBuilder.DropTable(
                name: "salary_grant_details");

            migrationBuilder.DropTable(
                name: "salary_standard");

            migrationBuilder.DropTable(
                name: "salary_standard_details");

            migrationBuilder.DropTable(
                name: "Tesc");

            migrationBuilder.DropTable(
                name: "training");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
