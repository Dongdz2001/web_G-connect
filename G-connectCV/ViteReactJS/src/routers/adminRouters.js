import { loadable } from '../shared/utils';

const adminRouters = [
    {
        path: '/demo1',
        component: loadable(() => import('../modules/example/Demo1'))
    },
    {
        path: '/logout',
        component: loadable(() => import('../modules/logout/Logout')),
    },
    {
        path: '/profile',
        component: loadable(() => import('../modules/profile/Profile'))
    },
    {
        path: '/location-list',
        component: loadable(() => import('../modules/location/LocationList'))
    },
    {
        path: '/location-form/:location_id',
        component: loadable(() => import('../modules/location/LocationForm'))
    },
    {
        path: '/user-list',
        component: loadable(() => import('../modules/user/UserList'))
    },
    {
        path: '/user-form/:user_id',
        component: loadable(() => import('../modules/user/UserForm'))
    },
    {
        path: '/user-list/form/:user_id',
        component: loadable(() => import('../modules/user/UserForm'))
    },
    {
        path: '/role-list',
        component: loadable(() => import('../modules/role/RoleList'))
    },
    {
        path: '/module-list',
        component: loadable(() => import('../modules/module/ModuleList'))
    },
    {
        path: '/gallery-module',
        component: loadable(() => import('../modules/gallery/GalleryManager'))
    },
    {
        path: '/post-list',
        component: loadable(() => import('../modules/post/PostList'))
    },
    {
        path: '/post-form/:post_id',
        component: loadable(() => import('../modules/post/PostForm'))
    },
    {
        path: '/category-list',
        component: loadable(() => import('../modules/category/CategoryList'))
    },
    {
        path: '/slide-list',
        component: loadable(() => import('../modules/slide/SlideList'))
    },
    {
        path: '/slide-form/:slide_id',
        component: loadable(() => import('../modules/slide/SlideForm'))
    },

    {
        path: '/calculation-unit-list',
        component: loadable(() => import('../modules/calculation-unit/CalculationUnitList'))
    },
    {
        path: '/calculation-unit-form/:calculation_unit_id',
        component: loadable(() => import('../modules/calculation-unit/CalculationUnitForm'))
    },
    /*
    {
        path: '/ticket-inventory-form/:ticket_inventory_id',
        component: loadable(() => import('../modules/ticket-inventory/TicketInventoryForm'))
    },
    {
        path: '/ticket-inventory-list',
        component: loadable(() => import('../modules/ticket-inventory/TicketInventoryList'))
    },
    {
        path: '/statistic-inventory',
        component: loadable(() => import('../modules/ticket-inventory/StatisticInventory'))
    },*/

    //order
    {
        path: '/order-form/:order_id',
        component: loadable(() => import('../modules/order/OrderForm'))
    },
    {
        path: '/order-list',
        component: loadable(() => import('../modules/order/OrderList'))
    },
    // store
    {
        path: '/store-form/:store_id',
        component: loadable(() => import('../modules/store/StoreForm'))
    },
    {
        path: '/store-list',
        component: loadable(() => import('../modules/store/StoreList'))
    },
    // account member
    {
        path: '/account-member-form/:account_member_id',
        component: loadable(() => import('../modules/account-member/AccountMemberForm'))
    },
    {
        path: '/account-member-list',
        component: loadable(() => import('../modules/account-member/AccountMemberList'))
    },
    {
        path: '/province-list',
        component: loadable(() => import('../modules/province/ProvinceList'))
    },
    {
        path: '/province-form/:province_id',
        component: loadable(() => import('../modules/province/ProvinceForm'))
    },
    {
        path: '/district-list',
        component: loadable(() => import('../modules/district/DistrictList'))
    },
    {
        path: '/district-form/:district_id',
        component: loadable(() => import('../modules/district/DistrictForm'))
    },
    /*
    {
        path: '/ward-list',
        component: loadable(() => import('../modules/ward/WardList'))
    },
    {
        path: '/ward-form/:ward_id',
        component: loadable(() => import('../modules/ward/WardForm'))
    },
    */
   
    


    {
        path: '/ClientCorsOrigins',
        component: loadable(() => import('../modules/ClientCorsOrigins/ClientCorsOriginsList'))
    },
    {
        path: '/ClientCorsOrigins-form/:id',
        component: loadable(() => import('../modules/ClientCorsOrigins/ClientCorsOriginsForm'))
    },
    {
        path: '/ClientCorsOrigins-view/:id',
        component: loadable(() => import('../modules/ClientCorsOrigins/ClientCorsOriginsFormView'))
    },

    {
        path: '/qtht_cau_hinh_ma',
        component: loadable(() => import('../modules/qtht_cau_hinh_ma/qtht_cau_hinh_maList'))
    },
    {
        path: '/qtht_cau_hinh_ma-form/:id',
        component: loadable(() => import('../modules/qtht_cau_hinh_ma/qtht_cau_hinh_maForm'))
    },


    {
        path: '/qtht_chuc_vu',
        component: loadable(() => import('../modules/qtht_chuc_vu/qtht_chuc_vuList'))
    },
    {
        path: '/qtht_chuc_vu-form/:id',
        component: loadable(() => import('../modules/qtht_chuc_vu/qtht_chuc_vuForm'))
    },


    {
        path: '/qtht_dieu_huong',
        component: loadable(() => import('../modules/qtht_dieu_huong/qtht_dieu_huongList'))
    },
    {
        path: '/qtht_dieu_huong-form/:id',
        component: loadable(() => import('../modules/qtht_dieu_huong/qtht_dieu_huongForm'))
    },


    {
        path: '/qtht_file_dinh_kem',
        component: loadable(() => import('../modules/qtht_file_dinh_kem/qtht_file_dinh_kemList'))
    },
    {
        path: '/qtht_file_dinh_kem-form/:id',
        component: loadable(() => import('../modules/qtht_file_dinh_kem/qtht_file_dinh_kemForm'))
    },


    {
        path: '/qtht_google_config',
        component: loadable(() => import('../modules/qtht_google_config/qtht_google_configList'))
    },
    {
        path: '/qtht_google_config-form/:id',
        component: loadable(() => import('../modules/qtht_google_config/qtht_google_configForm'))
    },


    {
        path: '/qtht_nguoi_dung',
        component: loadable(() => import('../modules/qtht_nguoi_dung/qtht_nguoi_dungList'))
    },
    {
        path: '/qtht_nguoi_dung-form/:id',
        component: loadable(() => import('../modules/qtht_nguoi_dung/qtht_nguoi_dungForm'))
    },


    {
        path: '/qtht_nguoi_dung_2_nhom_nguoi_dung',
        component: loadable(() => import('../modules/qtht_nguoi_dung_2_nhom_nguoi_dung/qtht_nguoi_dung_2_nhom_nguoi_dungList'))
    },
    {
        path: '/qtht_nguoi_dung_2_nhom_nguoi_dung-form/:id',
        component: loadable(() => import('../modules/qtht_nguoi_dung_2_nhom_nguoi_dung/qtht_nguoi_dung_2_nhom_nguoi_dungForm'))
    },


    {
        path: '/qtht_nhat_ky_he_thong',
        component: loadable(() => import('../modules/qtht_nhat_ky_he_thong/qtht_nhat_ky_he_thongList'))
    },
    {
        path: '/qtht_nhat_ky_he_thong-form/:id',
        component: loadable(() => import('../modules/qtht_nhat_ky_he_thong/qtht_nhat_ky_he_thongForm'))
    },


    {
        path: '/qtht_nhat_ky_he_thong_loai',
        component: loadable(() => import('../modules/qtht_nhat_ky_he_thong_loai/qtht_nhat_ky_he_thong_loaiList'))
    },
    {
        path: '/qtht_nhat_ky_he_thong_loai-form/:id',
        component: loadable(() => import('../modules/qtht_nhat_ky_he_thong_loai/qtht_nhat_ky_he_thong_loaiForm'))
    },


    {
        path: '/qtht_nhom_nguoi_dung',
        component: loadable(() => import('../modules/qtht_nhom_nguoi_dung/qtht_nhom_nguoi_dungList'))
    },
    {
        path: '/qtht_nhom_nguoi_dung-form/:id',
        component: loadable(() => import('../modules/qtht_nhom_nguoi_dung/qtht_nhom_nguoi_dungForm'))
    },


    {
        path: '/qtht_nhom_nguoi_dung_2_dieu_huong',
        component: loadable(() => import('../modules/qtht_nhom_nguoi_dung_2_dieu_huong/qtht_nhom_nguoi_dung_2_dieu_huongList'))
    },
    {
        path: '/qtht_nhom_nguoi_dung_2_dieu_huong-form/:id',
        component: loadable(() => import('../modules/qtht_nhom_nguoi_dung_2_dieu_huong/qtht_nhom_nguoi_dung_2_dieu_huongForm'))
    },
//ALl


    {
        path: '/GC_CHUC_NANG',
        component: loadable(() => import('../modules/GC_CHUC_NANG/GC_CHUC_NANGList'))
    },
    {
        path: '/GC_CHUC_NANG-form/:id',
        component: loadable(() => import('../modules/GC_CHUC_NANG/GC_CHUC_NANGForm'))
    },
    {
        path: '/GC_CHUC_NANG-vỉew/:id',
        component: loadable(() => import('../modules/GC_CHUC_NANG/GC_CHUC_NANGFormView'))
    },


    {
        path: '/GC_CONG_VIEC',
        component: loadable(() => import('../modules/GC_CONG_VIEC/GC_CONG_VIECList'))
    },
    {
        path: '/GC_CONG_VIEC-form/:id',
        component: loadable(() => import('../modules/GC_CONG_VIEC/GC_CONG_VIECForm'))
    },


    {
        path: '/GC_CONG_VIEC_CHECKLIST',
        component: loadable(() => import('../modules/GC_CONG_VIEC_CHECKLIST/GC_CONG_VIEC_CHECKLISTList'))
    },
    {
        path: '/GC_CONG_VIEC_CHECKLIST-form/:id',
        component: loadable(() => import('../modules/GC_CONG_VIEC_CHECKLIST/GC_CONG_VIEC_CHECKLISTForm'))
    },


    {
        path: '/GC_CONG_VIEC_PHAN_CONG',
        component: loadable(() => import('../modules/GC_CONG_VIEC_PHAN_CONG/GC_CONG_VIEC_PHAN_CONGList'))
    },
    {
        path: '/GC_CONG_VIEC_PHAN_CONG-form/:id',
        component: loadable(() => import('../modules/GC_CONG_VIEC_PHAN_CONG/GC_CONG_VIEC_PHAN_CONGForm'))
    },


    {
        path: '/GC_DM_LINH_VUC',
        component: loadable(() => import('../modules/GC_DM_LINH_VUC/GC_DM_LINH_VUCList'))
    },
    {
        path: '/GC_DM_LINH_VUC-form/:id',
        component: loadable(() => import('../modules/GC_DM_LINH_VUC/GC_DM_LINH_VUCForm'))
    },


    {
        path: '/GC_DM_LOAI_CHECK_LIST',
        component: loadable(() => import('../modules/GC_DM_LOAI_CHECK_LIST/GC_DM_LOAI_CHECK_LISTList'))
    },
    {
        path: '/GC_DM_LOAI_CHECK_LIST-form/:id',
        component: loadable(() => import('../modules/GC_DM_LOAI_CHECK_LIST/GC_DM_LOAI_CHECK_LISTForm'))
    },


    {
        path: '/GC_DM_LOAI_DU_AN',
        component: loadable(() => import('../modules/GC_DM_LOAI_DU_AN/GC_DM_LOAI_DU_ANList'))
    },
    {
        path: '/GC_DM_LOAI_DU_AN-form/:id',
        component: loadable(() => import('../modules/GC_DM_LOAI_DU_AN/GC_DM_LOAI_DU_ANForm'))
    },
    {
        path: '/GC_DM_LOAI_DU_AN-view/:id',
        component: loadable(() => import('../modules/GC_DM_LOAI_DU_AN/GC_DM_LOAI_DU_ANFormView'))
    },


    {
        path: '/GC_DM_TRANG_THAI',
        component: loadable(() => import('../modules/GC_DM_TRANG_THAI/GC_DM_TRANG_THAIList'))
    },
    {
        path: '/GC_DM_TRANG_THAI-form/:id',
        component: loadable(() => import('../modules/GC_DM_TRANG_THAI/GC_DM_TRANG_THAIForm'))
    },


    {
        path: '/GC_DU_AN',
        component: loadable(() => import('../modules/GC_DU_AN/GC_DU_ANList'))
    },
    {
        path: '/GC_DU_AN-form/:id',
        component: loadable(() => import('../modules/GC_DU_AN/GC_DU_ANForm'))
    },
    {
        path: '/GC_DU_AN-view/:id',
        component: loadable(() => import('../modules/GC_DU_AN/GC_DU_ANFormView'))
    },


    {
        path: '/GC_LICH_HANG_NGAY',
        component: loadable(() => import('../modules/GC_LICH_HANG_NGAY/GC_LICH_HANG_NGAYList'))
    },
    {
        path: '/GC_LICH_HANG_NGAY-form/:id',
        component: loadable(() => import('../modules/GC_LICH_HANG_NGAY/GC_LICH_HANG_NGAYForm'))
    },


    {
        path: '/GC_LICH_TUAN',
        component: loadable(() => import('../modules/GC_LICH_TUAN/GC_LICH_TUANList'))
    },
    {
        path: '/GC_LICH_TUAN-form/:id',
        component: loadable(() => import('../modules/GC_LICH_TUAN/GC_LICH_TUANForm'))
    },


    {
        path: '/GC_VAN_DE_CAN_GIAI_QUYET',
        component: loadable(() => import('../modules/GC_VAN_DE_CAN_GIAI_QUYET/GC_VAN_DE_CAN_GIAI_QUYETList'))
    },
    {
        path: '/GC_VAN_DE_CAN_GIAI_QUYET-form/:id',
        component: loadable(() => import('../modules/GC_VAN_DE_CAN_GIAI_QUYET/GC_VAN_DE_CAN_GIAI_QUYETForm'))
    },

]
export { adminRouters };