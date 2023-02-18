// <-----------------------------add_information_controller-------------------------------->

// thêm thông tin sinh viên mới nhập vào bảng
function addInformationToTable() {
  // Kiểm tra xem có trường nào trống không
  if (checkEmptyField()) return 0;

  // gọi ra table đang hiển thị thông tin
  var outputTbl = document.getElementById("table-display-student");

  // Thêm thẻ "tr" vào outputTbl
  var output = document.createElement("tr");
  outputTbl.appendChild(output);

  // Thêm các thông tin sinh viên thành 1 dòng mới trong bảng "table-display-student"
  output.innerHTML += `<td> <input type="checkbox" name="checkbox" value=\"${getInputCodeStudent()}\"> </td>`;
  output.innerHTML += "<td>" + getInputCodeStudent() + "</td>";
  output.innerHTML += "<td>" + getInputNameStudent() + "</td>";
  output.innerHTML += "<td>" + getInputDateStudent() + "</td>";
  output.innerHTML += "<td>" + getInputGenderStudent() + "</td>";
  output.innerHTML += "<td>" + getInputFacultyStudent() + "</td>";
  output.innerHTML += `<td> <div style=\"padding-top: 30px;\"> <button type=\"button\" class=\"btn btn-edit\" value=\"${getInputCodeStudent()}\" onclick=\"delete_func(this)\">Xóa</button> <button class=\"btn btn-edit\" value=\"${getInputCodeStudent()}\" onclick=\"edit_Student_In_Table(this)\" >Sửa</button> </div> </td>`;

  // Thêm dữ liệu sinh viên mới vào mảng manager_student
  manager.add_Student(
    new Student(
      getInputCodeStudent(),
      getInputNameStudent(),
      getInputDateStudent(),
      getInputGenderStudent(),
      getInputFacultyStudent()
    )
  );

  // Thiết lập trạng thái trống cho input "code" và "tên sinh viên"
  var temp_input_add_student =
    document.getElementsByClassName("input-add-student");
  temp_input_add_student[0].value = "";
  temp_input_add_student[1].value = "";
}

