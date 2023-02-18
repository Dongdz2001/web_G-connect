// cập nhật lại thông tin sinh viên trong bảng
function update_information_student_in_table() {
  if (checkEmptyField()) {
    return "error system!";
  }
  console.log(manager.check_code_student_exist(getInputCodeStudent()));
  var s = String(getInputCodeStudent()).replace(/\s/g, '');
  if (manager.check_code_student_exist(s)) {
    var student_temp = new Student(
        getInputCodeStudent(),
        getInputNameStudent(),
        getInputDateStudent(),
        getInputGenderStudent(),
        getInputFacultyStudent()
      );
      manager.set_Student_Value_By_Code(student_temp.get_Code(), student_temp);
      render_table_student();
  } else {
    alert("không tìm thấy mã sinh viên này trong bảng");
  }
 
}
