//<----------------------------------------  check_value_add_information  ------------------------------------------>

// Kiểm tra xem tên sinh viên và mã sinh viên có cái nào bị trống không
function checkEmptyField() {
  // Thiết lập trạng thái ẩn ban đầu
  hide_show_code_student(1);
  hide_show_name_student(1);
  hide_show_gender_student(1);
  hide_show_date_student(1);

  // khởi tạo biến kiểm tra trạng thái rỗng
  var check = false;
  // check mã sv
  if (getInputCodeStudent() == "") {
    hide_show_code_student(0);
    check = true;
  }
  // check tên sv
  if (getInputNameStudent() == "") {
    hide_show_name_student(0);
    check = true;
  }
  // check chọn ngày sinh của sinh viên
  if (getInputDateStudent() === "undefined/undefined/") {
    hide_show_date_student(0);
    check = true;
  }
  // check giới tính
  if (check_gender_radio_selected()) {
    hide_show_gender_student(0);
    check = true;
  }

  return check;
}
// ẩn hiện message cần nhập mã sinh viên
function hide_show_code_student(swit) {
  var x = document.getElementById("message-code-student");
  if (swit == 0) {
    x.style.display = "block";
  } else {
    x.style.display = "none";
  }
}

// ẩn hiện message cần nhập tên sinh viên
function hide_show_name_student(swit) {
  var x = document.getElementById("message-name-student");
  if (swit == 0) {
    x.style.display = "block";
  } else {
    x.style.display = "none";
  }
}

// ẩn hiện message cần chọn giới tính sinh viên
function hide_show_gender_student(swit) {
  var x = document.getElementById("message-gender-student");
  if (swit == 0) {
    x.style.display = "block";
  } else {
    x.style.display = "none";
  }
}
// ẩn hiện message cần chọn ngày sinh của sinh viên
function hide_show_date_student(swit) {
  var x = document.getElementById("message-date-student");
  if (swit == 0) {
    x.style.display = "block";
  } else {
    x.style.display = "none";
  }
}

// kiểm tra gender radio đã được chọn hay chưa
function check_gender_radio_selected() {
  // lấy ra giá trị của phần tử chọn giới tính sinh viên theo "name" là "gender"
  var genderStudent = document.getElementsByName("gender");
  console.log(genderStudent[0].checked === genderStudent[1].checked);

  // kiểm tra xem input[radio] của trường gender cái nào được chọn để gán giá trị tương ứng là nam hay nữ và trả về kết quả
  return genderStudent[0].checked == genderStudent[1].checked;
}