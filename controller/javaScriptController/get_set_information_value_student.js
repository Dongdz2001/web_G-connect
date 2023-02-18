// <-----------------------------   get_information_value_student  -------------------------------->

// lấy ra thông tin giới tính của sinh viên mới trong bảng thêm mới sinh viên
function getInputGenderStudent() {
  // lấy ra giá trị của phần tử chọn giới tính sinh viên theo "name" là "gender"
  var genderStudent = document.getElementsByName("gender");

  // kiểm tra xem input[radio] của trường gender cái nào được chọn để gán giá trị tương ứng là nam hay nữ và trả về kết quả
  let gender = genderStudent[0].checked === true ? "Nam" : "Nữ";
  return gender;
}

// thiết lập value trên thẻ "input-gender" bằng một giá trị nào đó
function setInputGenderStudent(value) {
  document.getElementsByName("gender")[value].checked = true;
  document.getElementsByName("gender")[1-value].checked = false;
}

// lấy ra tên của sinh viên trong bảng thêm mới sinh viên
function getInputNameStudent() {
  // tìm tên của sinh viên theo class với tên input-add-student
  var nameStudent =
    document.getElementsByClassName("input-add-student") ?? "none";

  // do có 2 class cùng tên là input-add-student nên giá trị trường này là phần tử thứ 2
  return nameStudent[1].value;
}

// thiết lập value trên thẻ "input-name" bằng một giá trị nào đó
function setInputNameStudent(value) {
  document.getElementsByClassName("input-add-student")[1].value = value;
}

// lấy ra mã sinh viên
function getInputCodeStudent() {
  // lấy thông tin mã sinh viên trong input-add-student id
  var codeStudent =
    document.getElementsByClassName("input-add-student") ?? "none";

  // do có 1 class cùng tên là input-add-student nên giá trị trường này là phần tử thứ 1
  return codeStudent[0].value;
}
// thiết lập value trên thẻ "input-code" bằng một giá trị nào đó
function setInputCodeStudent(value) {
  document.getElementsByClassName("input-add-student")[0].value = value;
}

// lấy ra ngày tháng năm sinh của sinh viên trong form thêm mới sinh viên
function getInputDateStudent() {
  // lấy ra value của date-student đã chọn
  var dateStudent = document.getElementById("date-student").value ?? " none";
  // formatt lại kiểu dữ liệu theo định dạng DD/MM/YYYY
  let arr = String(dateStudent).split("-");
  return arr[2] + "/" + arr[1] + "/" + arr[0];
}
// thiết lập value trên thẻ "input-date" bằng một giá trị nào đó
function setInputDateStudent(value) {
  document.getElementById("date-student").value = value;
}


// lấy ra thông tin khoa của sinh viên đã nhập trong form thêm mới sinh viên
function getInputFacultyStudent() {
  // Lấy ra thông tin của khoa trong faculty-section-studen id
  var e = document.getElementById("faculty-section-student");

  // xử lý section đã được chọn và trả về 1 string là option đã chọn
  var value = e.value;
  var text = e.options[e.selectedIndex].text;
  return text;
}
// thiết lập value trên thẻ "input-faculty" bằng một giá trị nào đó
function setInputFacultyStudent(value) {
  document.getElementById("faculty-section-student").value = value;
}

// hiển thị thông tin sinh viên trong cửa sổ console
function getInputAllInformation() {
  console.log(
    getInputCodeStudent() +
      " " +
      getInputNameStudent() +
      " " +
      getInputDateStudent() +
      " " +
      getInputGenderStudent() +
      " " +
      getInputFacultyStudent()
  );
}