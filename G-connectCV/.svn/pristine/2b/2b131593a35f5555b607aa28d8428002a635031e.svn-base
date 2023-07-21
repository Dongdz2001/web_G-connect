import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-GC_LICH_TUAN'
class GC_LICH_TUANBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-GC_LICH_TUAN' }, props);
        super(_props);
    }

    getAllRef_id_nguoi_thuc_hien() {
        return this.getAllRef('/link-qtht_nguoi_dung/select');
    }
}
const GC_LICH_TUANService = new GC_LICH_TUANBaseService();
export { GC_LICH_TUANService };
