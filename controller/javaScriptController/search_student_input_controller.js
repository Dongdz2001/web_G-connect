// <------------------------ Search informatin in the student table -----------------------

// lấy ra giá trị value-string trong input của  mục tìm kiếm sinh viên
function get_value_input_table() {
  var valueInputSearch = document.getElementsByName("txtTuKhoa")[0].value;
  return valueInputSearch;
}

// Xóa value trong 'input_search;
function delete_value_search() {
  document.getElementsByName("txtTuKhoa")[0].value = "";
}

// Kiểm tra xem từ khóa có thuộc lĩnh vực khoa hay không
function check_search_khoa(input) {
  input = input.replaceAll("  ", "");
  lsit_key = [
    "cntt",
    "công nghệ thông tin",
    "khmt",
    "khoa học máy tính",
    "cdt",
    "cơ điện tử",
    "thys",
    "tin học y sinh",
  ];

  check_flag = false;
  lsit_key.forEach((element) => {
    if (input == element) {
      check_flag = true;
      return true;
    }
  });

  return check_flag;
}

// Kiểm tra xem search theo mã sinh viên hay theo ngày sinh của sinh viên
function get_search_order_code_and_date(input) {
  input = input.replaceAll(" ", "");
  var check_flag = false;
  char.forEach((element) => {
    if (input.includes(element)) {
      check_flag = true;
    }
  });
  if (check_flag == true) {
    return 3;
  } else {
    return 1;
  }
}

// Kiểm tra string vào có là 'text-string' hay 'number-string'
function isNumeric(value) {
  char.forEach((element) => {
    value = value.replaceAll(element, "");
  });
  return /^-?\d+$/.test(value);
}

// Xử lý input nhập vào và in ra thứ tự tìm kiếm
// Ở đây ta định nghĩa thứ tự search như sau
// 1 - search theo mã sinh viên
// 2 - search theo tên sinh viên
// 3 - search theo ngày tháng năm sinh của sinh viên
// 4 - search theo khoa của sinh viên
// 5 - search theo giới tính của sinh viên
function get_order_search(input) {
  input = input.replaceAll("  ", " ");
  console.log(isNumeric(input));
  if (!isNumeric(input)) {
    if (check_search_khoa(input)) {
      return 4;
    } else {
      if (input.includes("#")) {
        return 5;
      } else {
        return 2;
      }
    }
  } else {
    return get_search_order_code_and_date(input);
  }
}

// Tìm kiếm thông tin trong bảng theo các tiêu chí
function search_input_table_student() {
  // lấy giá trị nhập
  var value_input_search = get_value_input_table();

  // chọn chức năng tìm kiếm
  var order_search = get_order_search(value_input_search);
  // thực hiện chức năng tìm kiếm theo require đã chọn
  var list_result_students = manager.get_list_Student();
  switch (order_search) {
    case 1:
      list_result_students = manager.search_student_by_code(
        value_input_search,
        list_result_students
      );
      break;
    case 2:
      list_result_students = manager.search_student_by_name(
        value_input_search,
        list_result_students
      );
      break;
    case 3:
      list_result_students = manager.search_student_by_date(
        value_input_search,
        list_result_students
      );
      break;
    case 4:
      list_result_students = manager.search_student_by_faculty(
        value_input_search,
        list_result_students
      );
      break;
    case 5:
      list_result_students = manager.search_student_by_gender(
        value_input_search,
        list_result_students
      );
      break;
  }
  // var list_result_students_name = manager.search_student_by_name(value_input_search);
  // var list_result_students_gender = manager.search_student_by_gender(value_input_search);
  // var list_result_students_faculty = manager.search_student_by_faculty(value_input_search);
  // var list_result_students_code = manager.search_student_by_code(value_input_search);
  //   var list_result_students_date = manager.search_student_by_date(value_input_search);
  render_table_student_by_list_student_object(list_result_students);
}
