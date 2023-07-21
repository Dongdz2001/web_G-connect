import 'bootstrap';

//import "primereact/resources/themes/saga-blue/theme.css";  //theme
import 'styles/themes/saga-blue-custom.css';
import "primereact/resources/primereact.min.css";          //core css
import "primeicons/primeicons.css";
import "primeflex/primeflex.css";

import 'bootstrap/dist/css/bootstrap.min.css';
import 'styles/adminlte.core.css';
import 'styles/adminlayout.scss';
import 'styles/custom-scroll.scss';
import 'styles/loadingoverlay-ui.scss';

import * as React from 'react';
import axios from 'axios';
import { appSetting } from 'shared/app-settings';
import {
    Routes,
    Route,
    Link,
    useNavigate,
    useLocation,
    Navigate,
    Outlet,
    // Redirect,
} from 'react-router-dom';
import { BrowserRouter } from "react-router-dom";
import { fakeAuthProvider } from './auth';
import AuthLayout from './layouts/AuthLayout';

import { store, persistor } from './store';
import { Provider } from 'react-redux';
import { PersistGate } from 'redux-persist/integration/react';
import LoginComponent from 'modules/login/LoginComponent';
import { useSelector } from "react-redux";

import { oauthService } from 'services/oauthService';
import { useDispatch } from 'react-redux';
import { setToken } from 'store/oauth/oauthSlice';
import Logout from 'modules/logout/Logout';

axios.defaults.baseURL = appSetting.API_URL;
export default function App() {

    return (
        <Provider store={store}>
            <PersistGate persistor={persistor}>
                <AuthProvider>
                    <BrowserRouter>
                        <Routes>
                            <Route element={<Layout />}>
                                <Route path="/public" element={<PublicPage />} />
                                <Route path="/login" element={<LoginComponent />} />
                                <Route path="/logout" element={<Logout />} />
                                <Route element={<RequireAuth />}>
                                    <Route path='*' element={<AuthLayout />} />
                                </Route>
                            </Route>
                            <Route path="*" element={<NotFound />} />
                        </Routes>

                    </BrowserRouter>
                </AuthProvider>
            </PersistGate>
        </Provider>
    );
}
function Layout() {

    return (
        <Outlet />
    );
}

interface AuthContextType {
    user: any;
    signin: (user: string, callback: VoidFunction) => void;
    signout: (callback: VoidFunction) => void;
}

let AuthContext = React.createContext<AuthContextType>(null!);

function AuthProvider({ children }: { children: React.ReactNode }) {
    let [user, setUser] = React.useState<any>(null);

    let signin = (newUser: string, callback: VoidFunction) => {
        return fakeAuthProvider.signin(() => {
            setUser(newUser);
            callback();
        });
    };

    let signout = (callback: VoidFunction) => {
        return fakeAuthProvider.signout(() => {
            setUser(null);
            callback();
        });
    };

    let value = { user, signin, signout };

    return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}

function useAuth() {
    return React.useContext(AuthContext);
}

function RequireAuth() {
    const oauthStore = useSelector((state: any) => state.oauth);
    let location = useLocation();
    // tạm bỏ login
    if (!oauthStore.token && !sessionStorage.getItem('aspSessionId')) {
        window.location.assign('/login');
    }
    return <Outlet />;
}



function PublicPage() {
    console.log('Public')
    return <h3>Public</h3>;
}

function NotFound() {
    return <h3>NotFound</h3>;
}
