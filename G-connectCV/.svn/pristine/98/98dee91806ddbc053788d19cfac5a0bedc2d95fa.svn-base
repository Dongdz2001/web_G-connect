import { t } from "i18next";
import { useEffect, useState, useRef } from "react";
import { useDispatch } from "react-redux";
import { Link, Outlet, Route, Routes } from "react-router-dom";
import { useMedia } from "shared/hooks/useMedia";
import { removeToken, setTokenLMS } from "store/oauth/oauthSlice";
import { useOnClickOutside } from "shared/hooks/useOnClickOutside";
import { clientRouters } from "routers/clientRouters";
import { getCurrentUserDefault } from "shared/utils/getCurrentUserDefault";
import { Dialog } from "primereact/dialog";
import Profile from "modules/profile/Profile";

export default function ClientLayout() {
  const { id } = getCurrentUserDefault();
  const dispatch = useDispatch();
  const refLeftMenu = useRef();
  const lmsMenuQLCV = useRef();
  const [toggleLeftMenu, setToggleLeftMenu] = useState(false);
  const [showProfile, setShowProfile] = useState(false);
  const [toggle, setToggle] = useState(false);
  const breakpoint2 = useMedia();
  const is_super_admin = getCurrentUserDefault().super_admin;

  const toggleMenu = () => {
    if (!toggle) {
      document.body.classList.add("sidebar-open");
      if (breakpoint2.isLg) {
        document.body.classList.add("sidebar-collapse");
      }
      if (breakpoint2.isMd) {
        document.body.classList.remove("sidebar-collapse");
      }
    } else {
      document.body.classList.remove("sidebar-open");
      document.body.classList.remove("sidebar-collapse");
    }
    setToggle(!toggle);
  };
  useOnClickOutside(refLeftMenu, () => {
    if (breakpoint2.isXs || breakpoint2.isSm) {
      document.body.classList.remove("sidebar-open");
      document.body.classList.remove("sidebar-collapse");
      setToggle(false);
    }
    if (breakpoint2.isMd) {
      document.body.classList.add("sidebar-collapse");
      setToggle(false);
    }
  });
  const onClickMenu = (ref) => {
    if (!toggleLeftMenu) {
      ref.current.classList.add("menu-is-opening");
      ref.current.classList.add("menu-open");
    } else {
      ref.current.classList.remove("menu-is-opening");
      ref.current.classList.remove("menu-open");
    }
    setToggleLeftMenu(!toggleLeftMenu);
  };
  
  return (
    <div>
      <Dialog
        showHeader={false}
        showfooter='false'
        visible={showProfile}
        onHide={() => setShowProfile(false)}
        position="center"
        breakpoints={{ "960px": "80vw" }}
        style={{ width: "40vw" }}
      >
        <div className="flex justify-content-center flex-column">
          <Profile
            fnClose={() => setShowProfile(false)}
          />
        </div>
      </Dialog>
      <div style={{
        marginLeft: '265px',
        padding: '5px',
        paddingBottom: '0px'
      }}>
        <h3>QUẢN LÝ CÔNG VIỆC G-CONNECT</h3>
      </div>
      <nav className="main-header navbar navbar-expand navbar-white navbar-light">
        <ul className="navbar-nav">
          <li className="nav-item">
            <a className="nav-link" onClick={() => toggleMenu()}>
              <i className="fas fa-bars"></i>
            </a>
          </li>
          <li className="nav-item d-none d-sm-inline-block">
            <a className="nav-link" href="/">
              Trang chủ
            </a>
          </li>
          <li className="nav-item d-none d-sm-inline-block">
            <a href="#" className="nav-link">
              Liên hệ
            </a>
          </li>
        </ul>
        <ul className="navbar-nav ml-auto">
          <li>
            <Link className="nav-link" to={null} onClick={() => {
                setShowProfile(true);
                return false;
              }}>
              {getCurrentUserDefault().ten}
            </Link>
          </li>
          <li className="nav-item dropdown">
            <a
              className="nav-link"
              data-toggle="dropdown"
              href="/login"
              title="logout"
              onClick={() => {
                dispatch(removeToken());
              }}
            >
              <i className="pi pi-sign-out" />
            </a>
          </li>
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
              <Link
                className="nav-link"
                to={"/client/lich-tuan"}
              >
                <i className="nav-icon far fa-plus-square" />
                <p>{"Lịch tuần"}</p>
              </Link>
            </li>
            <li className="nav-item">
              <Link
                className="nav-link"
                to={"/client/time-sheet"}
              >
                <i className="nav-icon far fa-plus-square" />
                <p>{"Giờ làm việc"}</p>
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to={"/client/du-an"}>
                <i className="nav-icon far fa-plus-square" />
                <p>{"Dự án"}</p>
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to={"/client/chuc-nang"}>
                <i className="nav-icon far fa-plus-square" />
                <p>{"Chức năng"}</p>
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to={"/client/cong-viec"}>
                <i className="nav-icon far fa-plus-square" />
                <p>{"Công việc"}</p>
              </Link>
            </li>
            <li className="nav-item">
              <Link
                className="nav-link"
                to={"/client/van-de"}
              >
                <i className="nav-icon far fa-plus-square" />
                <p>{"Các vấn đề cần giải quyết"}</p>
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to={"/client/phan-cong"}>
                <i className="nav-icon far fa-plus-square" />
                <p>{"Phân công công việc"}</p>
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to={"/client/check-list"}>
                <i className="nav-icon far fa-plus-square" />
                <p>{"Check-list kiểm thử"}</p>
              </Link>
            </li>
            {is_super_admin && <li className="nav-item">
              <a href="/admin/ClientCorsOrigins" className="nav-link">
                <i className="nav-icon far fa-plus-square" />
                <p>Quản trị</p>
              </a>
            </li>}
          </ul>
        </div>
      </aside>
      <div className="content-wrapper">
        <div className="p-3">
          <Routes>
            {clientRouters.map(({ path, component: Component }, index) => (
              //console.log(route)
              <Route path={path} key={index} element={<Component />} />
            ))}
          </Routes>
          <Outlet />
        </div>
      </div>
    </div>
  );
}
