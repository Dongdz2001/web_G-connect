import { useEffect, useState, useRef, useCallback } from 'react';
import { adminRouters } from 'routers/adminRouters';
import { Outlet, Route, Routes, Link } from 'react-router-dom';
import { useBreakpoint } from 'shared/hooks/useBreakPoint';
import { useMedia } from 'shared/hooks/useMedia';
import { useOnClickOutside } from 'shared/hooks/useOnClickOutside';
import { useSelector } from 'react-redux';
import { removeToken, setTokenLMS } from 'store/oauth/oauthSlice';
import { useDispatch } from 'react-redux';
import { useTranslation } from 'react-i18next'
const AdminLayout = () => {
  const { t, i18n } = useTranslation();
  const dispatch = useDispatch();
  const currentUser = useSelector(state => state.oauth);
  const systemMenu = useRef();
  const lmsMenu = useRef();
  const lmsMenuQLND = useRef();
  const lmsMenuQLCV = useRef();
  const [toggle, setToggle] = useState(false);
  const [toggleLeftMenu, setToggleLeftMenu] = useState(false);
  const breakpoint = useBreakpoint();
  const breakpoint2 = useMedia();
  const refLeftMenu = useRef();
  const warehouseRef = useRef();
  const facebookRef = useRef();
  useOnClickOutside(refLeftMenu, () => {

    if (breakpoint2.isXs || breakpoint2.isSm) {
      document.body.classList.remove('sidebar-open');
      document.body.classList.remove('sidebar-collapse');
      setToggle(false);
    }
    if (breakpoint2.isMd) {
      document.body.classList.add('sidebar-collapse');
      setToggle(false);
    }

  });


  const toggleMenu = () => {
    if (!toggle) {

      document.body.classList.add('sidebar-open');
      if (breakpoint2.isLg) {
        document.body.classList.add('sidebar-collapse');
      }
      if (breakpoint2.isMd) {
        document.body.classList.remove('sidebar-collapse');
      }

    } else {

      document.body.classList.remove('sidebar-open');
      document.body.classList.remove('sidebar-collapse');
    }
    setToggle(!toggle);
  }
  const onClickMenu = (ref)=>{
    if(!toggleLeftMenu){
      ref.current.classList.add('menu-is-opening')
      ref.current.classList.add('menu-open');
    }else {
      ref.current.classList.remove('menu-is-opening')
      ref.current.classList.remove('menu-open')
    } 
    setToggleLeftMenu(!toggleLeftMenu);
  }

  useEffect(() => {
    
  }, [])
  return (
    <>

      <div className='wrapper sidebar-mini'>
        <nav className="main-header navbar navbar-expand navbar-white navbar-light">
          <ul className="navbar-nav">
            <li className="nav-item">
              <a className="nav-link" onClick={() => toggleMenu()}><i className="fas fa-bars"></i></a>
            </li>
            <li className="nav-item d-none d-sm-inline-block">
              <a className="nav-link" href='/' >Home</a>
            </li>
            <li className="nav-item d-none d-sm-inline-block">
              <a href="#" className="nav-link">Contact</a>
            </li>
          </ul>
          <ul className="navbar-nav ml-auto">

            <li className="nav-item dropdown">
              <a className="nav-link" data-toggle="dropdown" href="/login" title='logout' onClick={()=>{dispatch(removeToken());}}>
                <i className="pi pi-sign-out" />
              </a>
            </li>

          </ul>

        </nav>

        <aside className="main-sidebar sidebar-dark-primary elevation-4" ref={refLeftMenu}>
          <a href="/" className="brand-link">
            <span className="brand-text font-weight-light">GC - QL Công việc</span>
          </a>
          <div className='sidebar'>
            <nav className='mt-2'>
              <div className="user-panel mt-3 pb-3 mb-3 d-flex">
                <div className="image">
                  { <img src={ currentUser?.UserImage ?? 'dist/img/user2-160x160.jpg' } className="img-circle elevation-2" alt="User Image" /> }
                </div>
                <div className="info w-100" >
                  <div className='d-flex flex-row justify-content-between '>
                    <div><Link to={{pathname:'/admin/profile'}} className="d-block">{(currentUser?.UserLastName ?? '') + ' ' + (currentUser?.UserMobileNumber ?? '') + ' ' + (currentUser?.UserMiddleName ?? '')}</Link> </div>

                  </div>

                </div>
              </div>
              <ul className="nav nav-pills nav-sidebar flex-column" data-widget="treeview" data-accordion="false">
                <li ref={lmsMenuQLCV} className="nav-item" >
                  <a href="#" className="nav-link" onClick={()=>onClickMenu(lmsMenuQLCV)}>
                    <i className="nav-icon fa fa-cog fa-user fa-lg pre" />
                    <p>
                    Quản lý công việc
                      <i className="right fas fa-angle-left" />
                    </p>
                  </a>
                  <ul className="nav nav-treeview">

                  <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/GC_DU_AN'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Dự án'}</p>
                      </Link>
                    </li>

                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/GC_CHUC_NANG'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Chức năng'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/GC_CONG_VIEC'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Công việc'}</p>
                      </Link>
                    </li>



                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/GC_CONG_VIEC_PHAN_CONG'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Title of GC_CONG_VIEC_PHAN_CONG'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/GC_CONG_VIEC_CHECKLIST'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Title of GC_CONG_VIEC_CHECKLIST'}</p>
                      </Link>
                    </li>

                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/GC_LICH_HANG_NGAY'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Timesheet'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/GC_LICH_TUAN'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Lịch tuần, lịch thực tập'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/GC_VAN_DE_CAN_GIAI_QUYET'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Vấn đề cần giải quyết'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/GC_DM_LOAI_DU_AN'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Danh mục Loại dự án'}</p>
                      </Link>
                    </li>

                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/GC_DM_LINH_VUC'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Danh mục Lĩnh vực'}</p>
                      </Link>
                    </li>

                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/GC_DM_TRANG_THAI'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Danh mục Trạng thái'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/GC_DM_LOAI_CHECK_LIST'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Danh mục Loại checklist'}</p>
                      </Link>
                    </li>


                  </ul>
                </li>
              </ul>
              <ul className="nav nav-pills nav-sidebar flex-column" data-widget="treeview" data-accordion="false">
                <li ref={lmsMenuQLND} className="nav-item" >
                  <a href="#" className="nav-link" onClick={()=>onClickMenu(lmsMenuQLND)}>
                    <i className="nav-icon fa fa-cog fa-user fa-lg pre" />
                    <p>
                    Quản lý hệ thống
                      <i className="right fas fa-angle-left" />
                    </p>
                  </a>
                  <ul className="nav nav-treeview">

                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/ClientCorsOrigins'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'URL được phép truy cập CORS'}</p>
                      </Link>
                    </li>
                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/qtht_cau_hinh_ma'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Title of qtht_cau_hinh_ma'}</p>
                      </Link>
                    </li>
                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/qtht_chuc_vu'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Title of qtht_chuc_vu'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/qtht_dieu_huong'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Title of qtht_dieu_huong'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/qtht_file_dinh_kem'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Title of qtht_file_dinh_kem'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/qtht_google_config'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Title of qtht_google_config'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/qtht_nguoi_dung'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Người dùng'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/qtht_nguoi_dung_2_nhom_nguoi_dung'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Title of qtht_nguoi_dung_2_nhom_nguoi_dung'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/qtht_nhat_ky_he_thong'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Nhật ký hệ thống'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/qtht_nhat_ky_he_thong_loai'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Title of qtht_nhat_ky_he_thong_loai'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/qtht_nhom_nguoi_dung'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Nhóm người dùng'}</p>
                      </Link>
                    </li>


                    <li className='nav-item'>
                      <Link className = 'nav-link' to={'/admin/qtht_nhom_nguoi_dung_2_dieu_huong'}>
                        <i className = 'far fa-circle nav-icon' />
                        <p>{'Title of qtht_nhom_nguoi_dung_2_dieu_huong'}</p>
                      </Link>
                    </li>
                  </ul>
                </li>
                <li ref={lmsMenu} className="nav-item" >
                  <a href="#" className="nav-link" onClick={()=>onClickMenu(lmsMenu)}>
                    <i className="nav-icon fa fa-cog fa-pencil-square-o fa-lg pre" />
                    <p>
                    KHÁC - tham khảo
                      <i className="right fas fa-angle-left" />
                    </p>
                  </a>
                  <ul className="nav nav-treeview">
                    <li className='nav-item '>
                      <Link className="nav-link" to={'/admin/post-list'}>
                        <i className="nav-icon fas fa-tachometer-alt" />
                        <p>
                          Bài viết
                        </p>
                      </Link>
                    </li>
                    <li className='nav-item '>
                      <Link className="nav-link" to={'/admin/account-member-list'}>
                        <i className="nav-icon fas fa-tachometer-alt" />
                        <p>
                          Thành viên
                        </p>
                      </Link>
                    </li>
                    <li className='nav-item '>
                      <Link className="nav-link" to={'/admin/order-list'}>
                        <i className="nav-icon fas fa-tachometer-alt" />
                        <p>
                          Đơn hàng
                        </p>
                      </Link>
                    </li>
                    <li className='nav-item '>
                      <Link className="nav-link" to={'/admin/gallery-module'}>
                        <i className="nav-icon fas fa-tachometer-alt" />
                        <p>
                          Thư viện ảnh
                        </p>
                      </Link>
                    </li>
                    <li className='nav-item '>
                      <Link className="nav-link" to={'/admin/slide-list'}>
                        <i className="nav-icon fas fa-tachometer-alt" />
                        <p>
                          Slide
                        </p>
                      </Link>
                    </li>
                    <li className='nav-item '>
                      <Link className="nav-link" to={'/admin/store-list'}>
                        <i className="nav-icon fas fa-tachometer-alt" />
                        <p>
                          Cửa hàng
                        </p>
                      </Link>
                    </li>
                    <li className='nav-item '>
                      <Link className="nav-link" to={'/admin/category-list'}>
                        <i className="nav-icon fas fa-tachometer-alt" />
                        <p>
                          Danh mục
                        </p>
                      </Link>
                    </li>
                    <li className='nav-item '>
                      <Link className="nav-link" to={'/admin/province-list'}>
                        <i className="nav-icon fas fa-tachometer-alt" />
                        <p>
                          Tỉnh/thành phố
                        </p>
                      </Link>
                    </li>

                    <li className='nav-item '>
                      <Link className="nav-link" to={'/admin/district-list'}>
                        <i className="nav-icon fas fa-tachometer-alt" />
                        <p>
                          Quận/huyện
                        </p>
                      </Link>
                    </li>

                    <li ref={warehouseRef} className="nav-item" >
                      <a href="#" className="nav-link" onClick={()=>onClickMenu(warehouseRef)}>
                        <i className="nav-icon fa-brands fa-facebook" />
                        <p>
                          Quản lý kho
                          <i className="right fas fa-angle-left" />
                        </p>
                      </a>
                      <ul className="nav nav-treeview">
                        <li className="nav-item">
                          <Link className="nav-link" to={'/admin/calculation-unit-list'}>
                            <i className="far fa-circle nav-icon" />
                            <p>Danh mục đơn vị tính</p>
                          </Link>
                        </li>

                      </ul>
                    </li>


                    <li ref={systemMenu} className="nav-item" >
                      <a href="#" className="nav-link" onClick={()=>onClickMenu(systemMenu)}>
                        <i className="nav-icon fas fa-tachometer-alt" />
                        <p>
                          System
                          <i className="right fas fa-angle-left" />
                        </p>
                      </a>
                      <ul className="nav nav-treeview">
                        <li className="nav-item">
                          <Link className="nav-link" to={'/admin/role-list'}>
                            <i className="far fa-circle nav-icon" />
                            <p>Roles</p>
                          </Link>
                        </li>
                        <li className="nav-item">
                          <Link className="nav-link" to={'/admin/module-list'}>
                            <i className="far fa-circle nav-icon" />
                            <p>Module</p>
                          </Link>
                        </li>
                      </ul>
                    </li>
                  </ul>
                </li>
              </ul>

              <li className="nav-item">
                <a href="/demo/lms-container" className="nav-link">
                  <i className="nav-icon far fa-plus-square" />
                  <p>Demo</p>
                </a>
              </li>

            </nav>
          </div>

        </aside>
        <div className='content-wrapper'>
          <div className='p-3'>
            <Routes>

              {adminRouters.map(({ path, component: Component }, index) =>
                //console.log(route)
                <Route path={path} key={index} element={<Component />} />
              )}

            </Routes>
            <Outlet />
          </div>

        </div>
        {/* <footer className="main-footer">
          <strong>Copyright © 2014-2021 <a href="/">OG</a>.</strong>
          All rights reserved.
          <div className="float-right d-none d-sm-inline-block">
            <b>Version</b> 3.2.0
          </div>
        </footer> */}
      </div>


    </>
  )
}
export default AdminLayout;