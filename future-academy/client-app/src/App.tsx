import React from "react";
import Layout from "./component/Layout/Layout";
import {BrowserRouter as Router, Routes, Route} from "react-router-dom";
import Main from "./pages/Main/Main";
import PATHS from "./data/paths";
import NotFound from "./pages/NotFound/NotFound";
import ScrollToTop from "./util/ScrollToTop";
import Courses from "./pages/Courses/Courses";
import Login from "./pages/Login/Login";
import {dropUser, setUser} from "./redux/userSlice";
import {useAppDispatch} from "./redux/hooks";
import axios from "axios";
import Profile from "./pages/Profile/Profile";

function App() {

  const dispatch = useAppDispatch();

  React.useEffect(() => {
    const login = localStorage.getItem("login")
    if (login != null) axios.get("/api/account/roleByLogin?login=" + login)
      .then(response => {
        if (response.data === "err") {
          dispatch(dropUser());
        } else {
          dispatch(setUser({login: login, role: response.data}))
        }
      })
  }, [])

  return (
    <>
      <Router>
        <ScrollToTop/>
        <Routes>
          <Route path={PATHS.MAIN} element={<Layout/>}>
            <Route index element={<Main/>}/>
            <Route path={PATHS.COURSES} element={<Courses/>}/>
            <Route path={PATHS.LOGIN} element={<Login/>}/>
            <Route path={PATHS.PROFILE+"/:login"} element={<Profile/>}/>
            <Route path="*" element={<NotFound/>}/>
          </Route>
        </Routes>
      </Router>
    </>
  );
}

export default App;
