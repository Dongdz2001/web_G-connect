﻿import React, { useEffect, useState, useRef } from "react";
import { useForm, Controller } from "react-hook-form";
import { InputText } from "primereact/inputtext";
import { InputTextarea } from "primereact/inputtextarea";
import { Button } from "primereact/button";
import CkEditor from "components/ckeditor4/CkEditor";
import {
  postStatusText,
  statusText,
  ACTIVE,
  DEACTIVE,
} from "shared/utils/appState";
import { SelectImgItem } from "components/SelectImgItem";
import { Checkbox } from "primereact/checkbox";
import { SelectButton } from "primereact/selectbutton";
import { AutoComplete } from "primereact/autocomplete";
import { Calendar } from "components/Calendar";
import { Dialog } from "primereact/dialog";
import { classNames } from "primereact/utils";
import { Card } from "primereact/card";
import { useParams } from "react-router-dom";
import { InputSwitch } from "primereact/inputswitch";
import { Dropdown } from "primereact/dropdown";

import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { decodeUnicode } from "shared/utils/decodeHtmlEntites";

import getFormErrorMessage from "shared/components/getFormErrorMessage";
import sessionStorage from "redux-persist/es/storage/session";

import { GC_LICH_TUANService } from "modules/GC_LICH_TUAN/GC_LICH_TUANService";

const GC_LICH_TUANFormView = (props) => {
  const { t, i18n } = useTranslation();
  let { id } = useParams();
  let itemId = props.id ?? id;
  const linkList = "/admin/GC_LICH_TUAN";
  const labelSave = "Lưu";
  const labelClose = "Đóng";
  const itemService = GC_LICH_TUANService;
  const dialogFooter = (
    <div className="flex justify-content-center">
      <Button
        label="OK"
        className="p-button-text"
        autoFocus
        onClick={() => setShowMessage(false)}
      />
    </div>
  );
  /* */
  let navigate = useNavigate();
  const defaultValues = {};
  const [formData, setFormData] = useState({});
  const [showMessage, setShowMessage] = useState(false);
  //{J}
  const {
    register,
    control,
    formState: { errors },
    handleSubmit,
    reset,
    watch,
    getValues,
    setValue,
  } = useForm({ defaultValues });
  const getFormErrorMessage = (name) => {
    return (
      errors[name] && <small className="p-error">{errors[name].message}</small>
    );
  };
  const getById = async (itemId) => {
    let result = await itemService.getById(itemId);
    reset(result.data);
  };
  useEffect(() => {
    if (itemId !== "new") getById(itemId);
    //{M}
  }, [window.location.href]);
  //{K}
  const close = async () => {
    if (props.fnClose) props.fnClose();
    else navigate(linkList);
    //navigate(-1);
  };
  return (
    <div>
      <Dialog
        visible={showMessage}
        onHide={() => setShowMessage(false)}
        position="top"
        footer={dialogFooter}
        showHeader={false}
        breakpoints={{ "960px": "80vw" }}
        style={{ width: "30vw" }}
      >
        <div className="flex justify-content-center flex-column pt-6 px-3"></div>
      </Dialog>

      <Card title={"Xem Lịch tuần, lịch thực tập"}>
        <div className="view-form">
          <div className="row">
            <div className={props.fnClose ? "text-center" : "col-12"}>
              <Button
                className="btnClose"
                style={{ width: 100 }}
                onClick={close.bind(this)}
                label={labelClose}
              ></Button>
            </div>

            <Controller
              name="xxx"
              control={control}
              render={({ field, fieldState }) => (
                <InputText {...field} className={"hide"} value={field.value} />
              )}
            />

            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="ten_id_nguoi_thuc_hien">{"Nhân viên"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="ten_id_nguoi_thuc_hien"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="thu2_sang">{"Thứ 2"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="thu2_sang"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="thu2_chieu">{"Title of thu2_chieu"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="thu2_chieu"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="thu3_sang">{"Thứ 3"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="thu3_sang"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="thu3_chieu">{"Title of thu3_chieu"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="thu3_chieu"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="thu4_sang">{"Thứ 4"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="thu4_sang"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="thu4_chieu">{"Title of thu4_chieu"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="thu4_chieu"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="thu5_sang">{"Thứ 5"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="thu5_sang"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="thu5_chieu">{"Title of thu5_chieu"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="thu5_chieu"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="thu6_sang">{"Thứ 6"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="thu6_sang"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="thu6_chieu">{"Title of thu6_chieu"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="thu6_chieu"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="thu7_sang">{"Thứ 7"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="thu7_sang"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="thu7_chieu">{"Title of thu7_chieu"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="thu7_chieu"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="nguoi_tao_id">{"Title of nguoi_tao_id"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="nguoi_tao_id"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="ngay_tao">{"Title of ngay_tao"}</label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="ngay_tao"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="nguoi_chinh_sua_id">
                  {"Title of nguoi_chinh_sua_id"}
                </label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="nguoi_chinh_sua_id"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="ngay_chinh_sua">
                  {"Title of ngay_chinh_sua"}
                </label>
              </div>
              <div className="col-sm-10">
                <Controller
                  name="ngay_chinh_sua"
                  control={control}
                  render={({ field, fieldState }) => (
                    <label className="p-inputtext">{field.value ?? ""}</label>
                  )}
                />
              </div>
            </div>

            <div className={props.fnClose ? "text-center" : "col-12"}>
              <Button
                className="btnClose"
                style={{ width: 100 }}
                onClick={close.bind(this)}
                label={labelClose}
              ></Button>
            </div>
          </div>
        </div>
      </Card>
    </div>
  );
};
export default GC_LICH_TUANFormView;