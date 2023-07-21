import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-GC_VAN_DE_CAN_GIAI_QUYET'
class GC_VAN_DE_CAN_GIAI_QUYETBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-GC_VAN_DE_CAN_GIAI_QUYET' }, props);
        super(_props);
    }

    getAllRef_id_chuc_nang() {
        return this.getAllRef('/link-GC_CHUC_NANG/select');
    }
    getAllRef_id_cong_viec() {
        return this.getAllRef('/link-GC_CONG_VIEC_PHAN_CONG/select');
    }
    getAllRef_id_nguoi_gap() {
        return this.getAllRef('/link-qtht_nguoi_dung/select');
    }
    getAllRef_id_nguoi_phoi_hop() {
        return this.getAllRef('/link-qtht_nguoi_dung/select');
    }
    getAllRef_id_nguoi_giai_quyet() {
        return this.getAllRef('/link-qtht_nguoi_dung/select');
    }
}
const GC_VAN_DE_CAN_GIAI_QUYETService = new GC_VAN_DE_CAN_GIAI_QUYETBaseService();
export { GC_VAN_DE_CAN_GIAI_QUYETService };
