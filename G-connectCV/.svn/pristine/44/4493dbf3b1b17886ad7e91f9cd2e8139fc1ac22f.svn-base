import React, { useState, useEffect, useRef } from "react";
import { setParamState } from "store/listParamSlice";
import { useSelector, useDispatch } from "react-redux";
import moment from "moment";
import "moment/locale/vi";
moment.locale("vi");
import "./TableTimeSheet.css";
import { Link } from "react-router-dom";
import { t } from "i18next";
import { Card } from "primereact/card";
import { mapPaginator } from "shared/utils";
import { GC_LICH_HANG_NGAYService } from "modules/GC_LICH_HANG_NGAY/GC_LICH_HANG_NGAYService";
import GC_LICH_HANG_NGAYForm from 'modules/GC_LICH_HANG_NGAY/GC_LICH_HANG_NGAYForm';
import { DEFAULT_LIST_PARAM, DEFAULT_LIST_PAGE } from "shared/app-settings";
import { getCurrentUserDefault } from "shared/utils/getCurrentUserDefault";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { Dialog } from "primereact/dialog";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';

  function TableBody(props) {
    const {
      daysInMonth,
      currentDate,
      monthlabel,
      yearr,
      checkInTime,
      checkOutTime,
      loading,
      loadingFuc,
    } = props;
    const openDialog = false;
    const linkEdit = "/EditSheetTable";
    const [listItems, setListItems] = useState(null);
    const [totalItems, setTotalItems] = useState(0);
    const [selectedId, setSelectedId] = useState(null);
    const [selectedItem, setSelectedItem] = useState(null);
    const [showDialogEdit, setShowDialogEdit] = useState(false);
    const fieldSortOrder = "ASC";
    const fieldSort = "id";
    const dispatch = useDispatch();
    const userId = getCurrentUserDefault().id;
    const is_super_admin = getCurrentUserDefault().super_admin;
    const listParamStore = useSelector((state) => {
      var param = null;
      if (
        state.listParam.find((st) => st && st.name == window.location.toString())
      )
        param = state.listParam.find(
          (st) => st && st.name == window.location.toString()
        ).param;
      return param;
    });
    const [lazyParams, setLazyParams] = useState({
      ...DEFAULT_LIST_PARAM,
      ...{
        sortField: fieldSort,
        sortOrder: fieldSortOrder == "ASC" ? -1 : 1,
      },
      ...listParamStore,
    });
    useEffect(() => {
      loadLazyData();
    }, [lazyParams.refresh, props.yearr, props.monthlabel, props.refresh]);
    useEffect(() => {
      setTimeout(() => {
        if (listParamStore && listParamStore.pageYOffset)
          window.scrollTo(0, listParamStore.pageYOffset);
      }, 100);

      // getListRef_id_nguoi_thuc_hien();
      // getListRef_id_cong_viec();
    }, [window.location.href]);
    const loadLazyData = () => {
      loadingFuc(true);
      let advanceSearch = mapPaginator(lazyParams);
      advanceSearch.filter = {month: props.monthlabel, year: props.yearr};
      return GC_LICH_HANG_NGAYService.filterPage(advanceSearch).then((res) => {
        setTotalItems(res.data.meta.total);
        setListItems(res.data.data);
        loadingFuc(false);
      });
    };
    const editItem = async (id, id_nguoi_thuc_hien, id_cong_viec, ngay) => {
      setSelectedId(id ?? 'new');
      setSelectedItem({id_nguoi_thuc_hien: id_nguoi_thuc_hien, id_cong_viec: id_cong_viec, ngay: ngay});
      dispatch(setParamState({ ...lazyParams, pageYOffset: window.pageYOffset }));
      if (!openDialog) setShowDialogEdit(true);
    };
    const closeDialog = async () => {
      setShowDialogEdit(false);
      await loadLazyData();
    };
    //  Trả về xâu dạng DD/mm xử lý từ chuỗi gốc
    const stringProcessYear = (chuoi) => {
      // Chuyển chuỗi về đối tượng Date trong JavaScript
      const date = new Date(chuoi);

      const thang = date.getYear();

      return thang;
    };
    const stringProcessDayMonth = (chuoi) => {
      // Chuyển chuỗi về đối tượng Date trong JavaScript
      const date = new Date(chuoi);

      // Lấy ngày và tháng từ đối tượng Date
      const ngay = String(date.getDate()).padStart(2, "0"); // Lấy ngày và đảm bảo có 2 chữ số
      const thang = String(date.getMonth() + 1).padStart(2, "0"); // Lấy tháng (bắt đầu từ 0) và đảm bảo có 2 chữ số

      // Tạo chuỗi ngày tháng mới theo định dạng "dd/mm"
      const ngayThang = `${ngay}/${thang}`;
      return ngayThang;
    };
    const stringProcessHourMinute = (chuoi) => {
      if(chuoi==null) return '';
      // Chuyển chuỗi về đối tượng Date trong JavaScript
      const date = new Date(chuoi);

      // Lấy ngày và tháng từ đối tượng Date
      const ngay = String(date.getHours()).padStart(2, "0"); // Lấy ngày và đảm bảo có 2 chữ số
      const thang = String(date.getMinutes()).padStart(2, "0"); // Lấy tháng (bắt đầu từ 0) và đảm bảo có 2 chữ số

      // Tạo chuỗi ngày tháng mới theo định dạng "dd/mm"
      const ngayThang = `${ngay}:${thang}`;
      return ngayThang;
    };

    const stringProcessMonthYear = (str) => {
      const date = new Date(str);
      const month = String(date.getMonth() + 1).padStart(2, "0");
      const year = String(date.getFullYear());
      return `${month}/${year}`;
    };

    const listItemsUserProject = [];
    listItems && listItems.map((row, index) => {
      if(!listItemsUserProject.find(x=>x.ten_id_nguoi_thuc_hien==row.ten_id_nguoi_thuc_hien && x.ten_du_an==row.ten_du_an)) listItemsUserProject.push({ten_id_nguoi_thuc_hien: row.ten_id_nguoi_thuc_hien, id_nguoi_thuc_hien: row.id_nguoi_thuc_hien, ten_du_an: row.ten_du_an
        , tong_so_gio: listItems.filter(y=>y.ten_id_nguoi_thuc_hien==row.ten_id_nguoi_thuc_hien && y.ten_du_an==row.ten_du_an).reduce((partialSum, y) => partialSum + y.so_gio, 0)
      });
    });
    listItemsUserProject.sort((a, b) => {
      const nameA = a.ten_id_nguoi_thuc_hien.toUpperCase(); // ignore upper and lowercase
      const nameB = b.ten_id_nguoi_thuc_hien.toUpperCase(); // ignore upper and lowercase
      if (nameA < nameB) {
        return -1;
      }
      if (nameA > nameB) {
        return 1;
      }
    
      // names must be equal
      return 0;
    });
    console.log(listItemsUserProject)
    
    const listItemsUser = [];
    listItems && listItems.map((row, index) => {
      if(!listItemsUser.find(x=>x.ten_id_nguoi_thuc_hien==row.ten_id_nguoi_thuc_hien && x.ten_id_cong_viec==row.ten_id_cong_viec)) listItemsUser.push({ten_id_nguoi_thuc_hien: row.ten_id_nguoi_thuc_hien, ten_id_cong_viec: row.ten_id_cong_viec, id_nguoi_thuc_hien: row.id_nguoi_thuc_hien, id_cong_viec: row.id_cong_viec, ten_du_an: row.ten_du_an});
    });
    listItemsUser.sort((a, b) => {
      const nameA = a.ten_id_nguoi_thuc_hien.toUpperCase(); // ignore upper and lowercase
      const nameB = b.ten_id_nguoi_thuc_hien.toUpperCase(); // ignore upper and lowercase
      if (nameA < nameB) {
        return -1;
      }
      if (nameA > nameB) {
        return 1;
      }
    
      // names must be equal
      return 0;
    });

    return (
      <tbody>
        <Dialog visible={showDialogEdit} onHide={() => setShowDialogEdit(false)} style={{width: '600px'}} 
        position="center"
          showHeader={false} showFooter={false}
        >
          <GC_LICH_HANG_NGAYForm id={selectedId} item={selectedItem} fnClose={closeDialog} />
        </Dialog>
        {listItemsUser &&
          listItemsUser.map((row, index) => {
            const Cells = [];

            for (let i = 1; i <= daysInMonth; i++) {
              const currentDateObj = moment(currentDate).date(i).startOf("day");
              
              let timesheet = listItems.find(x=>x.ten_id_nguoi_thuc_hien==row.ten_id_nguoi_thuc_hien && x.ten_id_cong_viec==row.ten_id_cong_viec && stringProcessDayMonth(x.ngay_lam_viec)==(i<10?'0':'')+i+'/'+monthlabel.toString());
              if(timesheet != null) {
                if(row.id_nguoi_thuc_hien === getCurrentUserDefault().id)
                  Cells.push(
                    <td key={index*100+i} className="tdsheet">
                      <p style={{ width: "80px", marginBottom: "0px" }}>{stringProcessHourMinute(timesheet.ngay_checkin)}</p>
                      <p style={{ width: "80px", marginBottom: "0px" }}>
                        {timesheet.so_gio ? <button
                          onClick={(el) => editItem( timesheet.id, timesheet.id_nguoi_thuc_hien, timesheet.id_cong_viec, timesheet.ngay_lam_viec )}
                          style={{
                            border: "none",
                            background: "none",
                            padding: "0px",
                            border: '1px solid red',
                            padding: '0px 7px',
                            borderRadius: '50%'
                          }}
                        >
                          {timesheet.so_gio ? timesheet.so_gio : ""}
                        </button> : <button
                          onClick={(el) => editItem( timesheet.id, timesheet.id_nguoi_thuc_hien, timesheet.id_cong_viec, timesheet.ngay_lam_viec )}
                          style={{
                            border: "none",
                            background: "none",
                            padding: "0px",
                          }}
                        >
                          {"__"}
                        </button>}
                      </p>
                      <p style={{ width: "80px", marginBottom: "0px" }}>{stringProcessHourMinute(timesheet.ngay_checkout)}</p>
                    </td>
                  );
                else
                  Cells.push(
                    <td key={index*100+i} className="tdsheet">
                      <p style={{ width: "80px", marginBottom: "0px" }}>{stringProcessHourMinute(timesheet.ngay_checkin)}</p>
                      <p style={{ width: "80px", marginBottom: "0px" }}>
                        {timesheet.so_gio ? timesheet.so_gio : "-"}
                      </p>
                      <p style={{ width: "80px", marginBottom: "0px" }}>{stringProcessHourMinute(timesheet.ngay_checkout)}</p>
                    </td>
                  );
              }
              else {
                if(row.id_nguoi_thuc_hien === getCurrentUserDefault().id)
                  Cells.push(
                    <td key={index*100+i} className="tdsheet">
                      <button
                        onClick={() => editItem(null, row.id_nguoi_thuc_hien, row.id_cong_viec, (i<10?'0':'')+i+'/'+monthlabel.toString()+'/'+stringProcessYear(currentDateObj))}
                        style={{
                          border: "none",
                          background: "none",
                          padding: "0px",
                        }}
                      >
                        __
                      </button>
                    </td>
                  );
                else
                  Cells.push(
                    <td key={index*100+i} className="tdsheet">
                      
                    </td>
                  );
              }
            }
            return (
              <tr key={row.id} className="trsheet">
                <td className="tdsheet">
                  {" "}
                  <p style={{ marginTop: "30px" }}> {index + 1} </p>{" "}
                </td>
                <td className="tdsheet">
                  <p style={{ width: "150px", marginTop: "30px" }}>
                    {" "}
                    {row.ten_id_nguoi_thuc_hien}{" "}
                  </p>{" "}
                </td>
                <td className="tdsheet">
                  <p style={{ widthMax: "200px", marginTop: "20px" }}>
                    {" "}
                    {row.ten_id_cong_viec}{" "} 
                  </p>
                </td>
                {Cells}
              </tr>
            );
          })}

          <tr><td></td></tr>
          <tr><td></td></tr>
          <tr><td></td></tr>

          <tr>
            <th style={{textAlign: 'center'}}>STT</th>
            <th style={{textAlign: 'center'}}>TÊN NHÂN VIÊN</th>
            <th style={{textAlign: 'center'}}>DỰ ÁN</th>
            <th style={{textAlign: 'center'}} colSpan={2}>TỔNG SỐ GIỜ</th>
          </tr>
          
          {listItemsUserProject &&
            listItemsUserProject.map((row, index) => {

            return (
              <tr key={row.id} className="trsheet">
                <td className="tdsheet">
                  {" "}
                  <p style={{ marginTop: "30px" }}> {index + 1} </p>{" "}
                </td>
                <td className="tdsheet">
                  <p style={{ width: "150px", marginTop: "30px" }}>
                    {" "}
                    {row.ten_id_nguoi_thuc_hien}{" "}
                  </p>{" "}
                </td>
                <td className="tdsheet">
                  <p style={{ widthMax: "200px", marginTop: "20px" }}>
                    {" "}
                    {row.ten_du_an}{" "} 
                  </p>
                </td>
                <td colSpan={2} className="tdsheet">
                  <p style={{ widthMax: "200px", marginTop: "20px" }}>
                    {" "}
                    {row.tong_so_gio}{" "} 
                  </p>
                </td>
              </tr>
            );
          })
        }
      </tbody>
    );
  }
  export default TableBody;
