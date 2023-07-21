import { useState } from "react";
import { Outlet, Route, Routes, Link } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { useSelector } from "react-redux";
import { useCurrentUserDefault } from "shared/hooks/useCurrentUserDefault";
import { setLanguage } from "store/oauth/oauthSlice";
import { useDispatch } from "react-redux";
import "./newlayout.scss";
import { getCurrentUserDefault } from "shared/utils/getCurrentUserDefault";

const NewLayout = () => {
  const [isToggle, setIsToggle] = useState(false);
  const dispatch = useDispatch();
  const userFirstName = useSelector((state) => state.oauth.UserFirstName) || "";
  const currentUserDefault = useCurrentUserDefault();
  const [visibleRight, setVisibleRight] = useState(false);
  const { t, i18n } = useTranslation();
  const changeLanguageHandler = (lang) => {
    i18n.changeLanguage(lang);
    dispatch(setLanguage(lang));
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
  return (
    <>
      <div className="wrapper">
        <nav className="main-header navbar navbar-expand navbar-white navbar-light bg-primary navbar-custom">
          <ul className="navbar-nav">
            <li className="nav-item">
              <a
                className="nav-link"
                onClick={toggle}
                data-widget="pushmenu"
                role="button"
              >
                <i className="fas fa-bars" style={{ color: "white" }} />
              </a>
            </li>
          </ul>
          <ul className="navbar-nav ml-auto">
            <div className="test mt-1"></div>
            <div className="dropdown">
              <a
                className="nav-link dropdown-toggle text-white"
                href="#"
                data-bs-toggle="dropdown"
                aria-expanded="false"
              >
                {t("rbkey_LnggClnLBL", "Ngôn ngữ")}
              </a>
              <ul className="dropdown-menu dropdown-menu-end">
                <li>
                  <a
                    onClick={() => changeLanguageHandler("en")}
                    className="dropdown-item"
                    href="#"
                  >
                    EN
                  </a>
                </li>
                <li>
                  <a
                    onClick={() => changeLanguageHandler("vi")}
                    className="dropdown-item"
                    href="#"
                  >
                    VI
                  </a>
                </li>
              </ul>
            </div>
            <div className="dropdown">
              <a
                className="nav-link dropdown-toggle text-white"
                href="#"
                data-bs-toggle="dropdown"
                aria-expanded="false"
              >
                {/* <img src="https://github.com/mdo.png" alt="hugenerd" width={30} height={30} className="rounded-circle" /> */}
                <span className="d-none d-sm-inline">{userFirstName}</span>
              </a>
              <ul className="dropdown-menu dropdown-menu-end">
                <li>
                  <a className="dropdown-item" href="/profile/user">
                    {t("rbkey_PrflLBL", "Hồ sơ")}
                  </a>
                </li>
                <li>
                  <a className="dropdown-item" href="#">
                    {t("rbkey_RlLBL", "Vai trò")}
                  </a>
                </li>
                <li>
                  <a className="dropdown-item" href="/logout">
                    {t("rbkey_LgtLBL", "Đăng xuất")}
                  </a>
                </li>
              </ul>
            </div>
            {/* <div className="dropdown">
                        <a href="#" className="d-flex align-items-center text-white text-decoration-none dropdown-toggle" id="dropdownUser1" data-bs-toggle="dropdown" aria-expanded="false">
                            <img src="https://github.com/mdo.png" alt="hugenerd" width={30} height={30} className="rounded-circle" />
                            <span className="d-none d-sm-inline">{userFirstName}</span>
                        </a>
                        <ul className="dropdown-menu dropdown-menu-end">
                            <li><a className="dropdown-item" href="/profile/user">{t('rbkey_PrflLBL', 'Hồ sơ')}</a></li>
                            <li><a className="dropdown-item" href="#">{t('rbkey_RlLBL', 'Vai trò')}</a></li>
                            <li><a className="dropdown-item" href="/logout">{t('rbkey_LgtLBL', 'Đăng xuất')}</a></li>
                        </ul>
                    </div> */}
          </ul>
        </nav>

        <aside className="main-sidebar main-sidebar-custom sidebar-dark-primary elevation-4">
          <div className="sidebar  d-flex flex-column align-items-center align-items-sm-start pt-2 pl-0 text-white min-vh-100">
            <ul
              className="nav nav-pills nav-sidebar  flex-column mb-sm-auto mb-0 align-items-center align-items-sm-start"
              id="menu1"
            >
              <li className="nav-item">
                <Link to={{ pathname: "/overview" }} className="nav-link">
                  <i className="nav-icon fas fa-tachometer-alt" />
                  <p>{t("rbkey_ct_ovrvw", "Tổng quan")}</p>
                </Link>
                <ul
                  style={{ display: "none" }}
                  className="collapse nav flex-column"
                  id="tongquan"
                  data-bs-parent="#menu1"
                ></ul>
              </li>

              <li className="nav-item">
                <a href="/demo/lms-container" className="nav-link">
                  <i className="nav-icon far fa-plus-square" />
                  <p>Demo</p>
                </a>
              </li>

              <li className="nav-item">
                <a href="/admin/ClientCorsOrigins" className="nav-link">
                  <i className="nav-icon far fa-plus-square" />
                  <p>LMS Admin Vị trí</p>
                </a>
              </li>

              <li className="nav-item">
                <a href="/client/ClientCorsOrigin" className="nav-link">
                  <i className="nav-icon far fa-plus-square" />
                  <p>LMS Client</p>
                </a>
              </li>

              <li className="nav-item">
              {/* /admin/ClientCorsOrigins */}
              {/* onClick={handleClickShowTableTimeSheet} */}
                <a href="/table-component/TableTimeSheet" className="nav-link" >  
                  <i className="nav-icon far fa-plus-square" />
                  <p>Lịch Ngày TimeSheet </p>
                </a>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to={"/issues/issue/" + getCurrentUserDefault().id}>
                  <i className="nav-icon far fa-plus-square" />
                  <p>{" Các vấn đề cần giải quyết"}</p>
                </Link>
              </li>
            </ul>
          </div>
        </aside>
        <div className="content-wrapper">
          <div className="container-fluid">
            <Routes></Routes>
            <Outlet />
          </div>
        </div>
      </div>
    </>
  );
};
export default NewLayout;