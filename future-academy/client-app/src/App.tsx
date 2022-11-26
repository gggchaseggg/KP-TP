import React from "react";
import Layout from "./component/Layout/Layout";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Main from "./pages/Main/Main";
import PATHS from "./data/paths";
import NotFound from "./pages/NotFound/NotFound";
import ScrollToTop from "./util/ScrollToTop";

function App() {
  return (
    <>
      <Router>
        <ScrollToTop />
        <Routes>
          <Route path={PATHS.MAIN} element={<Layout />}>
            <Route index element={<Main />} />
            <Route path="*" element={<NotFound />} />
          </Route>
        </Routes>
      </Router>
    </>
  );
}

export default App;
