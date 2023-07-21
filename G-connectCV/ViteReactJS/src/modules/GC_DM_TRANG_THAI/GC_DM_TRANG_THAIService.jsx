import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-GC_DM_TRANG_THAI'
class GC_DM_TRANG_THAIBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-GC_DM_TRANG_THAI' }, props);
        super(_props);
    }

}
const GC_DM_TRANG_THAIService = new GC_DM_TRANG_THAIBaseService();
export { GC_DM_TRANG_THAIService };
