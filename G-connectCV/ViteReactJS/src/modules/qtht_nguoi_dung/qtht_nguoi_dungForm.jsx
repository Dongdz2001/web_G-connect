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

import { qtht_nguoi_dungService } from "modules/qtht_nguoi_dung/qtht_nguoi_dungService";

const qtht_nguoi_dungForm = (props) => {
  const { t, i18n } = useTranslation();
  let { id } = useParams();
  let itemId = props.id ?? id;
  const linkList = "/admin/qtht_nguoi_dung";
  const labelSave = "Lưu";
  const labelClose = "Đóng";
  const itemService = qtht_nguoi_dungService;
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

  const [listRef_chuc_vu_id, setListRef_chuc_vu_id] = useState([]);
  const [listRef_file_dinh_kem_id, setListRef_file_dinh_kem_id] = useState([]);
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
    if (itemId === "new") {
      console.log(formData);
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

    getListRef_chuc_vu_id();
    getListRef_file_dinh_kem_id();
  }, [window.location.href]);

  const getListRef_chuc_vu_id = () => {
    return qtht_nguoi_dungService.getAllRef_chuc_vu_id().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      setListRef_chuc_vu_id(res.data);
    });
  };
  const getListRef_file_dinh_kem_id = () => {
    return qtht_nguoi_dungService.getAllRef_file_dinh_kem_id().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      setListRef_file_dinh_kem_id(res.data);
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
          (itemId === "new" ? "Thêm" : "Sửa") + " Title of qtht_nguoi_dung"
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
                <label htmlFor="tai_khoan">
                  {"Tài khoản"} <span className="p-error">(*)</span>
                </label>
                <Controller
                  name="tai_khoan"
                  control={control}
                  rules={{
                    required: {
                      value: true,
                      message: "Vui lòng nhập!",
                    },
                    maxLength: {
                      value: 255,
                      message: "Không quá 255 ký tự",
                    },
                    //validate: value => value === 'pwd' || "The passwords do not match",
                    //pattern: {
                    //  value: /^[a-zA-Z]+$/,
                    //  message: 'pattern'
                    //},
                  }}
                  render={({ field, fieldState }) => (
                    <InputTextarea
                      rows="3"
                      {...field}
                      value={field.value ?? ""}
                    />
                  )}
                />
                {getFormErrorMessage("tai_khoan", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="mat_khau">
                  {"Mật khẩu"} <span className="p-error">(*)</span>
                </label>
                <Controller
                  name="mat_khau"
                  control={control}
                  rules={{
                    required: {
                      value: true,
                      message: "Vui lòng nhập!",
                    },
                    maxLength: {
                      value: 255,
                      message: "Không quá 255 ký tự",
                    },
                    //validate: value => value === 'pwd' || "The passwords do not match",
                    //pattern: {
                    //  value: /^[a-zA-Z]+$/,
                    //  message: 'pattern'
                    //},
                  }}
                  render={({ field, fieldState }) => (
                    <InputTextarea
                      rows="3"
                      {...field}
                      value={field.value ?? ""}
                    />
                  )}
                />
                {getFormErrorMessage("mat_khau", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="salt_code">
                  {"Salt code"} <span className="p-error">(*)</span>
                </label>
                <Controller
                  name="salt_code"
                  control={control}
                  rules={{
                    required: {
                      value: true,
                      message: "Vui lòng nhập!",
                    },
                    maxLength: {
                      value: 32,
                      message: "Không quá 32 ký tự",
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
                {getFormErrorMessage("salt_code", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="ten">
                  {"Tên"} <span className="p-error">(*)</span>
                </label>
                <Controller
                  name="ten"
                  control={control}
                  rules={{
                    required: {
                      value: true,
                      message: "Vui lòng nhập!",
                    },
                    maxLength: {
                      value: 255,
                      message: "Không quá 255 ký tự",
                    },
                    //validate: value => value === 'pwd' || "The passwords do not match",
                    //pattern: {
                    //  value: /^[a-zA-Z]+$/,
                    //  message: 'pattern'
                    //},
                  }}
                  render={({ field, fieldState }) => (
                    <InputTextarea
                      rows="3"
                      {...field}
                      value={field.value ?? ""}
                    />
                  )}
                />
                {getFormErrorMessage("ten", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="trang_thai">
                  {"Trạng thái"} <span className="p-error">(*)</span>
                </label>
                <Controller
                  name="trang_thai"
                  control={control}
                  rules={{
                    required: {
                      value: true,
                      message: "Vui lòng nhập!",
                    },
                    maxLength: {
                      value: 11,
                      message: "Không quá 11 ký tự",
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
                {getFormErrorMessage("trang_thai", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="super_admin">
                  {"Super admin"} <span className="p-error">(*)</span>
                </label>
                <Controller
                  name="super_admin"
                  control={control}
                  rules={{
                    required: {
                      value: true,
                      message: "Vui lòng nhập!",
                    },
                    //validate: value => value === 'pwd' || "The passwords do not match",
                    //pattern: {
                    //  value: /^[a-zA-Z]+$/,
                    //  message: 'pattern'
                    //},
                  }}
                  render={({ field, fieldState }) => (
                    <InputSwitch
                      trueValue={ACTIVE}
                      falseValue={DEACTIVE}
                      tooltip={
                        field.value == ACTIVE
                          ? statusText.active
                          : statusText.deactive
                      }
                      checked={field.value}
                      onChange={(e) => field.onChange(e.target.value)}
                    />
                  )}
                />
                {getFormErrorMessage("super_admin", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="email">{"Email"}</label>
                <Controller
                  name="email"
                  control={control}
                  rules={{
                    maxLength: {
                      value: 255,
                      message: "Không quá 255 ký tự",
                    },
                    //validate: value => value === 'pwd' || "The passwords do not match",
                    //pattern: {
                    //  value: /^[a-zA-Z]+$/,
                    //  message: 'pattern'
                    //},
                  }}
                  render={({ field, fieldState }) => (
                    <InputTextarea
                      rows="3"
                      {...field}
                      value={field.value ?? ""}
                    />
                  )}
                />
                {getFormErrorMessage("email", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="so_dien_thoai">
                  {"Số điện thoại"}
                </label>
                <Controller
                  name="so_dien_thoai"
                  control={control}
                  rules={{
                    maxLength: {
                      value: 32,
                      message: "Không quá 32 ký tự",
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
                <label htmlFor="anh_dai_dien_url">
                  {"Ảnh đại điện(URL)"}
                </label>
                <Controller
                  name="anh_dai_dien_url"
                  control={control}
                  rules={{
                    maxLength: {
                      value: 1024,
                      message: "Không quá 1024 ký tự",
                    },
                    //validate: value => value === 'pwd' || "The passwords do not match",
                    //pattern: {
                    //  value: /^[a-zA-Z]+$/,
                    //  message: 'pattern'
                    //},
                  }}
                  render={({ field, fieldState }) => (
                    <CkEditor
                      editor="content"
                      id="content"
                      config={{ height: 300 }}
                      content={field.value}
                      events={{
                        change: (event) => {
                          field.onChange(event.editor.getData());
                        },
                      }}
                      className={classNames({
                        "p-invalid": fieldState.invalid,
                      })}
                    />
                  )}
                />
                {getFormErrorMessage("anh_dai_dien_url", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="is_dau_moi">{"Title of is_dau_moi"}</label>
                <Controller
                  name="is_dau_moi"
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
                    <InputSwitch
                      trueValue={ACTIVE}
                      falseValue={DEACTIVE}
                      tooltip={
                        field.value == ACTIVE
                          ? statusText.active
                          : statusText.deactive
                      }
                      checked={field.value}
                      onChange={(e) => field.onChange(e.target.value)}
                    />
                  )}
                />
                {getFormErrorMessage("is_dau_moi", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="chuc_vu_id">{"Title of chuc_vu_id"}</label>
                <Controller
                  name="chuc_vu_id"
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
                      options={listRef_chuc_vu_id}
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
                {getFormErrorMessage("chuc_vu_id", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="file_dinh_kem_id">
                  {"Title of file_dinh_kem_id"}
                </label>
                <Controller
                  name="file_dinh_kem_id"
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
                      options={listRef_file_dinh_kem_id}
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
                {getFormErrorMessage("file_dinh_kem_id", errors)}
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
export default qtht_nguoi_dungForm;
