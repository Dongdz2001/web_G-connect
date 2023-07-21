import React, { useEffect, useState, useRef } from "react";
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

const GC_LICH_TUANForm = (props) => {
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

  const [listRef_id_nguoi_thuc_hien, setListRef_id_nguoi_thuc_hien] = useState(
    []
  );
  // console.log(field);
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
  const onSubmit = async (formData) => {
    console.log(formData);
    if (itemId === "new") {
      await itemService.create(formData);
    } else {
      await itemService.update(itemId, formData);
    }
    if (props.fnLoadData) props.fnLoadData();
    if (props.fnClose) props.fnClose();
    else navigate(linkList);
  };
  const getById = async (itemId) => {
    let result = await itemService.getById(itemId);
    reset(result.data);
  };
  useEffect(() => {
    if (itemId !== "new") getById(itemId);

    getListRef_id_nguoi_thuc_hien();
  }, [window.location.href]);
  const getListRef_id_nguoi_thuc_hien = () => {
    return GC_LICH_TUANService.getAllRef_id_nguoi_thuc_hien().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      setListRef_id_nguoi_thuc_hien(res.data);
    });
  };
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

      <Card
        title={
          (itemId === "new" ? "Thêm" : "Sửa") + " Lịch tuần, lịch thực tập"
        }
      >
        <form className="p-fluid" onSubmit={handleSubmit(onSubmit)}>
          <div className="row">
            <div className={props.fnClose ? "text-center" : "col-12"}>
              <Button
                label={labelSave}
                icon="fa fa-save"
                style={{ width: "100px" }}
              />
              <Button
                className="btnClose"
                style={{ width: 100 }}
                onClick={close.bind(this)}
                label={labelClose}
              ></Button>
            </div>
            <br />
            <br />

            <Controller
              name="xxx"
              control={control}
              render={({ field, fieldState }) => (
                <InputText {...field} className={"hide"} value={field.value} />
              )}
            />

            <div className="col-12">
              <div className="col-sm-12">
                <h4 htmlFor="id_nguoi_thuc_hien">Nhân viên</h4>
                <Controller
                  name="id_nguoi_thuc_hien"
                  control={control}
                  rules={
                    {
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }
                  }
                  render={({ field, fieldState }) => (
                    <Dropdown
                      options={listRef_id_nguoi_thuc_hien}
                      optionValue="Value"
                      optionLabel="Text"
                      scrollHeight={"600px"}
                      className=""
                      {...field}
                      value={field.value ?? ""}
                      placeholder="--Chọn--"
                      showClear
                    />
                  )}
                />
                {getFormErrorMessage("id_nguoi_thuc_hien", errors)}
              </div>
            </div>
            <div>
              <h5>Thứ 2</h5>
              <div className="col-12">
                <div className="col-sm-12">
                  <label htmlFor="thu2_sang">{"Sáng"}</label>
                  <Controller
                    name="thu2_sang"
                    control={control}
                    rules={{
                      maxLength: {
                        value: 20,
                        message: "Không quá 20 ký tự",
                      },
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }}
                    render={({ field, fieldState }) => (
                      <InputText {...field} value={field.value ?? ""} />
                    )}
                  />
                  {getFormErrorMessage("thu2_sang", errors)}
                </div>
              </div>
              <div className="col-12">
                <div className="col-sm-12">
                  <label htmlFor="thu2_chieu">{"Chiều"}</label>
                  <Controller
                    name="thu2_chieu"
                    control={control}
                    rules={{
                      maxLength: {
                        value: 20,
                        message: "Không quá 20 ký tự",
                      },
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }}
                    render={({ field, fieldState }) => (
                      <InputText {...field} value={field.value ?? ""} />
                    )}
                  />
                  {getFormErrorMessage("thu2_chieu", errors)}
                </div>
              </div>
            </div>
            <div>
              <h4>Thứ 3</h4>
              <div className="col-12">
                <div className="col-sm-12">
                  <label htmlFor="thu3_sang">Sáng</label>
                  <Controller
                    name="thu3_sang"
                    control={control}
                    rules={{
                      maxLength: {
                        value: 20,
                        message: "Không quá 20 ký tự",
                      },
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }}
                    render={({ field, fieldState }) => (
                      <InputText {...field} value={field.value ?? ""} />
                    )}
                  />
                  {getFormErrorMessage("thu3_sang", errors)}
                </div>
              </div>
              <div className="col-12">
                <div className="col-sm-12">
                  <label htmlFor="thu3_chieu">Chiều</label>
                  <Controller
                    name="thu3_chieu"
                    control={control}
                    rules={{
                      maxLength: {
                        value: 20,
                        message: "Không quá 20 ký tự",
                      },
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }}
                    render={({ field, fieldState }) => (
                      <InputText {...field} value={field.value ?? ""} />
                    )}
                  />
                  {getFormErrorMessage("thu3_chieu", errors)}
                </div>
              </div>
            </div>
            <div>
              <h4>Thứ 4</h4>
              <div className="col-12">
                <div className="col-sm-12">
                  <label htmlFor="thu4_sang">Sáng</label>
                  <Controller
                    name="thu4_sang"
                    control={control}
                    rules={{
                      maxLength: {
                        value: 20,
                        message: "Không quá 20 ký tự",
                      },
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }}
                    render={({ field, fieldState }) => (
                      <InputText {...field} value={field.value ?? ""} />
                    )}
                  />
                  {getFormErrorMessage("thu4_sang", errors)}
                </div>
              </div>
              <div className="col-12">
                <div className="col-sm-12">
                  <label htmlFor="thu4_chieu">Chiều</label>
                  <Controller
                    name="thu4_chieu"
                    control={control}
                    rules={{
                      maxLength: {
                        value: 20,
                        message: "Không quá 20 ký tự",
                      },
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }}
                    render={({ field, fieldState }) => (
                      <InputText {...field} value={field.value ?? ""} />
                    )}
                  />
                  {getFormErrorMessage("thu4_chieu", errors)}
                </div>
              </div>
            </div>
            <div>
              <h4>Thứ 5</h4>
              <div className="col-12">
                <div className="col-sm-12">
                  <label htmlFor="thu5_sang">Sáng</label>
                  <Controller
                    name="thu5_sang"
                    control={control}
                    rules={{
                      maxLength: {
                        value: 20,
                        message: "Không quá 20 ký tự",
                      },
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }}
                    render={({ field, fieldState }) => (
                      <InputText {...field} value={field.value ?? ""} />
                    )}
                  />
                  {getFormErrorMessage("thu5_sang", errors)}
                </div>
              </div>
              <div className="col-12">
                <div className="col-sm-12">
                  <label htmlFor="thu5_chieu">Chiều</label>
                  <Controller
                    name="thu5_chieu"
                    control={control}
                    rules={{
                      maxLength: {
                        value: 20,
                        message: "Không quá 20 ký tự",
                      },
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }}
                    render={({ field, fieldState }) => (
                      <InputText {...field} value={field.value ?? ""} />
                    )}
                  />
                  {getFormErrorMessage("thu5_chieu", errors)}
                </div>
              </div>
            </div>
            <div>
              <h4>Thứ 6</h4>
              <div className="col-12">
                <div className="col-sm-12">
                  <label htmlFor="thu6_sang">Sáng</label>
                  <Controller
                    name="thu6_sang"
                    control={control}
                    rules={{
                      maxLength: {
                        value: 20,
                        message: "Không quá 20 ký tự",
                      },
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }}
                    render={({ field, fieldState }) => (
                      <InputText {...field} value={field.value ?? ""} />
                    )}
                  />
                  {getFormErrorMessage("thu6_sang", errors)}
                </div>
              </div>
              <div className="col-12">
                <div className="col-sm-12">
                  <label htmlFor="thu6_chieu">Chiều</label>
                  <Controller
                    name="thu6_chieu"
                    control={control}
                    rules={{
                      maxLength: {
                        value: 20,
                        message: "Không quá 20 ký tự",
                      },
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }}
                    render={({ field, fieldState }) => (
                      <InputText {...field} value={field.value ?? ""} />
                    )}
                  />
                  {getFormErrorMessage("thu6_chieu", errors)}
                </div>
              </div>
            </div>
            <div>
              <h4>Thứ 7</h4>
              <div className="col-12">
                <div className="col-sm-12">
                  <label htmlFor="thu7_sang">Sáng</label>
                  <Controller
                    name="thu7_sang"
                    control={control}
                    rules={{
                      maxLength: {
                        value: 20,
                        message: "Không quá 20 ký tự",
                      },
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }}
                    render={({ field, fieldState }) => (
                      <InputText {...field} value={field.value ?? ""} />
                    )}
                  />
                  {getFormErrorMessage("thu7_sang", errors)}
                </div>
              </div>
              <div className="col-12">
                <div className="col-sm-12">
                  <label htmlFor="thu7_chieu">Chiều</label>
                  <Controller
                    name="thu7_chieu"
                    control={control}
                    rules={{
                      maxLength: {
                        value: 20,
                        message: "Không quá 20 ký tự",
                      },
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }}
                    render={({ field, fieldState }) => (
                      <InputText {...field} value={field.value ?? ""} />
                    )}
                  />
                  {getFormErrorMessage("thu7_chieu", errors)}
                </div>
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <h4 htmlFor="so_dien_thoai">Số điện thoại</h4>
                <Controller
                  name="so_dien_thoai"
                  control={control}
                  rules={{
                    maxLength: {
                      value: 20,
                      message: "Không quá 20 ký tự",
                    },
                    //validate: value => value === 'pwd' || "The passwords do not match",
                    //pattern: {
                    //  value: /^[a-zA-Z]+$/,
                    //  message: 'pattern'
                    //},
                  }}
                  render={({ field, fieldState }) => (
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("so_dien_thoai", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <h4 htmlFor="link_bao_cao">Link báo cáo</h4>
                <Controller
                  name="link_bao_cao"
                  control={control}
                  rules={{
                    maxLength: {
                      value: 200,
                      message: "Không quá 200 ký tự",
                    },
                    //validate: value => value === 'pwd' || "The passwords do not match",
                    //pattern: {
                    //  value: /^[a-zA-Z]+$/,
                    //  message: 'pattern'
                    //},
                  }}
                  render={({ field, fieldState }) => (
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("link_bao_cao", errors)}
              </div>
            </div>
            <div className={props.fnClose ? "text-center" : "col-12"}>
              <Button
                label={labelSave}
                icon="fa fa-save"
                style={{ width: "100px" }}
              />
              <Button
                className="btnClose"
                style={{ width: 100 }}
                onClick={close.bind(this)}
                label={labelClose}
              ></Button>
            </div>
          </div>
        </form>
      </Card>
    </div>
  );
};
export default GC_LICH_TUANForm;
