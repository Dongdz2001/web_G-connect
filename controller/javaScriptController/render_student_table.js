// < ---------------------------- Render Table Student   ------------------------------------------ >

  
  // Render lại bảng đã khởi tạo
  function render_table_student() {
    delete_all_row_in_student_table();
    var outputTbl = document.getElementById("table-display-student");
    manager.get_list_Student().forEach((element) => {
      // Thêm thẻ "tr" vào outputTbl
      var output = document.createElement("tr");
      outputTbl.appendChild(output);
      // Thêm các thông tin sinh viên thành 1 dòng mới trong bảng "table-display-student"
      output.innerHTML += '<td> <input type="checkbox" name="checkbox"> </td>';
      output.innerHTML += "<td>" + element.get_Code() + "</td>";
      output.innerHTML += "<td>" + element.get_Name() + "</td>";
      output.innerHTML += "<td>" + element.get_Date() + "</td>";
      output.innerHTML += "<td>" + element.get_Gender() + "</td>";
      output.innerHTML += "<td>" + element.get_Faculty() + "</td>";
      output.innerHTML += `<td> <div style=\"padding-top: 30px;\"> <button type=\"button\" class=\"btn btn-edit\" value=\"${element.get_Code()}\" onclick=\"delete_func(this)\">Xóa</button> <button class=\"btn btn-edit\" value=\"${element.get_Code()}\" onclick=\"edit_Student_In_Table(this)\" >Sửa</button> </div> </td>`;
    });
  }

  // Render lại bảng đã khởi tạo theo 1 list students bất kỳ
  function render_table_student_by_list_student_object(student_Object_List) {
    delete_all_row_in_student_table();
    var outputTbl = document.getElementById("table-display-student");
    student_Object_List.forEach((element) => {
      // Thêm thẻ "tr" vào outputTbl
      var output = document.createElement("tr");
      outputTbl.appendChild(output);
      // Thêm các thông tin sinh viên thành 1 dòng mới trong bảng "table-display-student"
      output.innerHTML += '<td> <input type="checkbox" name="checkbox"> </td>';
      output.innerHTML += "<td>" + element.get_Code() + "</td>";
      output.innerHTML += "<td>" + element.get_Name() + "</td>";
      output.innerHTML += "<td>" + element.get_Date() + "</td>";
      output.innerHTML += "<td>" + element.get_Gender() + "</td>";
      output.innerHTML += "<td>" + element.get_Faculty() + "</td>";
      output.innerHTML += `<td> <div style=\"padding-top: 30px;\"> <button type=\"button\" class=\"btn btn-edit\" value=\"${element.get_Code()}\" onclick=\"delete_func(this)\">Xóa</button> <button class=\"btn btn-edit\" value=\"${element.get_Code()}\" onclick=\"edit_Student_In_Table(this)\" >Sửa</button> </div> </td>`;
    });
  }
  

  