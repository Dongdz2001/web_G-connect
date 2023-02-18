// Xoá tất cả các dòng trong table
function delete_all_row_in_student_table() {
  var tableHeaderRowCount = 1;
  var table = document.getElementById("table-display-student");
  var rowCount = table.rows.length;
  for (var i = tableHeaderRowCount; i < rowCount; i++) {
    table.deleteRow(tableHeaderRowCount);
  }
}

// xóa sinh viên trong bảng theo một vị trí xác định
function delete_func(deleteButton) {
  let text = "Bạn muốn xóa thông tin sinh viên này ?\n nhấn 'OK' để xóa hoặc 'Cancel' để thoát";
  if (confirm(text) == true) {
    manager.delete_Student_By_Code(deleteButton.value);
    render_table_student();
  } 
}

// Xóa nhiều sinh viên trong bảng bằng button xóa
function delete_multial_student() {
  let text = "Bạn muốn xóa thông tin nhiều sinh viên này cùng lúc không ? \n nhấn 'OK' để xóa --- 'Cancel' để thoát";
  if (confirm(text) == true) {
    var check_list_box_student = document.getElementsByName('checkbox');
    check_list_box_student.forEach(element => {
      if (element.checked) {
        manager.delete_Student_By_Code(element.value);
      }
    });
    
    render_table_student();
  }
}