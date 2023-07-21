import axios from "axios";
import React, { useState, useEffect, useRef } from 'react';
import { setParamState } from 'store/listParamSlice';
import { useSelector, useDispatch } from 'react-redux';
import moment from 'moment';
import 'moment/locale/vi';
moment.locale('vi');
import "./TableTimeSheet.css";
import { Link } from "react-router-dom";
import { t } from "i18next";
import { Card } from "primereact/card";
import { mapPaginator } from 'shared/utils';
import { GC_LICH_HANG_NGAYService  } from 'modules/GC_LICH_HANG_NGAY/GC_LICH_HANG_NGAYService';
import { DEFAULT_LIST_PARAM, DEFAULT_LIST_PAGE } from 'shared/app-settings';
import { getCurrentUserDefault  } from 'shared/utils/getCurrentUserDefault';
import GC_LICH_HANG_NGAYForm from 'modules/GC_LICH_HANG_NGAY/GC_LICH_HANG_NGAYForm';
import { Dialog } from "primereact/dialog";

import TableBody from './TableBody';
import { hide } from "@popperjs/core";
function TableTimeSheet() {
  const currentDate = new Date();
  const month = currentDate.getMonth() + 1;
  const [year, setYear] = useState(currentDate.getFullYear());
  // const daysInMonth = moment().daysInMonth();
  const headerCells = [];
  // const monthLabel = `${month < 10 ? "0" : ""}${month}`;
  const [monthLabel, setMonthLabel] = useState(`${month < 10 ? "0" : ""}${month}`);
  let daysInMonth = moment(`${year}-${monthLabel}`).daysInMonth();
  const [isToggle, setIsToggle] = useState(false);
  const [checkInTime, setCheckInTime] = useState(null);
  const [showDialogEdit, setShowDialogEdit] = useState(false);
  const [selectedId, setSelectedId] = useState(null);
  const [selectedItem, setSelectedItem] = useState(null);
  const [checkOutTime, setCheckOutTime] = useState(null);
  const [loading, setLoading] = useState(false);
  const [refresh, setRefresh] = useState(false);
  let intervalId = null;

  const closeDialog = async () => {
    setShowDialogEdit(false);
    //await loadLazyData();
  };
  const setDaysInMonth = (monthLabel) => {
    const currentDate = new Date();
    const year = currentDate.getFullYear();
    daysInMonth = moment(`${year}-${monthLabel}`).daysInMonth();
  };
  const prevMonthTimeSheet = () => {
    let numMonth = parseInt(monthLabel, 10); // Sử dụng let thay vì const để có thể gán lại giá trị
    numMonth = numMonth > 0 ? numMonth - 1 : numMonth;
    if(numMonth == 0) {
      numMonth = 12;
      setYear(year-1);
    }
    const monthStr = numMonth.toString().padStart(2, '0');
    setDaysInMonth(monthStr);
    setMonthLabel(monthStr); // Kiểm tra giá trị numMonth trước khi chuyển đổi thành chuỗi và thêm dấu '0' đầu chuỗi
  }
  const nextMountTimeSheet = () => {
    let numMonth = parseInt(monthLabel, 10); // Sử dụng let thay vì const để có thể gán lại giá trị
    numMonth = numMonth <= 12 ? numMonth + 1 : numMonth;
    if(numMonth == 13) {
      numMonth = 1;
      setYear(year+1);
    }
    const monthStr =  numMonth.toString().padStart(2, '0');
    setDaysInMonth(monthStr);
    setMonthLabel(monthStr); // Kiểm tra giá trị numMonth trước khi chuyển đổi thành chuỗi và thêm dấu '0' đầu chuỗi
  }
  const handleSetLoading = (newState) => {
    setLoading(newState);
  };

  const handleCheckIn = () => {
    GC_LICH_HANG_NGAYService.checkIn();
    setTimeout(()=>{
      setRefresh(!refresh);
    }, 500);
  };
    
  const handleCheckOut = () => {
    GC_LICH_HANG_NGAYService.checkOut();
    setTimeout(()=>{
      setRefresh(!refresh);
    }, 500);
  };
  
  const handleLogTime = () => {
    setShowDialogEdit(true);
  };
  
  const toggle = () => {
    if (!isToggle) {
      document.body.classList.add("sidebar-collapse");
    } else {
      document.body.classList.remove("sidebar-collapse");
    }
    setIsToggle(!isToggle);
    // document.body.classList.remove('overflow-y-disable');
  };
  for (let i = 1; i <= daysInMonth; i++) {
    const dayOfMonth = `${i < 10 ? "0" : ""}${i}`;
    const isBeforeToday = new Date(year, month - 1, i) < currentDate;
    if (isBeforeToday) {
      headerCells.push(
        <th key={i} className="thsheet ths" >
          <p style={{  marginTop: "20px" }}> {dayOfMonth}/{monthLabel} </p>
        </th>
      );
    } else {
      headerCells.push(
        <th key={i} className="thsheet ths" >
          <span style={{ color: "gray" }}>
          <p style={{  marginTop: "20px" }}> {dayOfMonth}/{monthLabel} </p>
          </span>
        </th>
      );
    }
  }

  return (
    
      <Card title={'Danh sách Giờ làm việc '} >
          <Dialog visible={showDialogEdit} 
          position="center" onHide={() => setShowDialogEdit(false)} style={{width: '600px'}} 
            showHeader={false} showFooter={false}
          >
            <GC_LICH_HANG_NGAYForm id={selectedId} item={selectedItem} fnClose={()=>{
              setTimeout(()=>{
                setRefresh(!refresh);
              }, 500);
              closeDialog();
            }} />
          </Dialog>
          <div className='titleTimeSheet'>
            <h2 className='titleSheetTable'>  </h2>
            <div style={{display: "flex" , marginBottom: "10px", justifyContent: 'center' }} >
              <button className='button-prev' onClick={() => prevMonthTimeSheet()}> {'<<'} </button>
              <div style={{margin: "10px 20px"}}><h1>{`${monthLabel}/${year}`}</h1></div>
              <button className='button-next' onClick={() => nextMountTimeSheet()} > {'>>'} </button>
            </div>
            <div className="button-container">
              <button className="check-in-button" style={{height:'70px'}} onClick={() => handleCheckIn()} >Giờ vào (08:30)</button>
              <button className="log-time-button" style={{height:'70px'}} onClick={() => handleLogTime()} >Giờ làm việc</button>
              <button className="check-out-button" style={{height:'70px'}} onClick={() => handleCheckOut()}>Giờ ra (17:30)</button>
            </div>
          </div>
         
          
        <div style={{ overflowX: "auto" }} >
          
          <table className={`tablesheet table ${loading ? 'table-loading' : ''}`}>
            <TableHeader
              daysInMonth={daysInMonth}
              headerCells={headerCells}
              currentDate={currentDate}
            />
            <TableBody 
                daysInMonth={daysInMonth}
                monthlabel={monthLabel}
                yearr={year} 
                refresh={refresh} 
                currentDate={currentDate}  
                checkInTime={checkInTime} 
                checkOutTime={checkOutTime} 
                loading={loading} 
                loadingFuc={handleSetLoading}/>
          </table>

        </div>
        </Card>
        
  );
}

function TableHeader(props) {
  const { headerCells } = props;

  return (
    <thead className="theadsheet">
      <tr className="trsheet">
        {/* <th className="thsheet">Edit</th> */}
        <th className="thsheet"> <p style={{marginTop: "20px" }}>STT</p> </th>
        <th className="thsheet"> <p style={{widthMax: "200px" , marginTop: "20px" }}> Tên Nhân Viên </p></th>
        <th className="thpositon thsheet"> <p style={{width: "100px" , marginTop: "20px" }}> Công việc </p> </th>
        {headerCells}
      </tr>
    </thead>
  );
}


export default TableTimeSheet;

          // <button className="edit-button"><i className="fas fa-edit"></i></button>
           // return <tbody>{RowsElements}</tbody>;