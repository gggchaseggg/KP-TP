import React from "react";
import Layout from "./component/Layout/Layout";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Main from "./pages/Main/Main";
import PATHS from "./data/paths";

function App() {
  return (
    <>
      <Router>
        <Routes>
          <Route path={PATHS.MAIN} element={<Layout />}>
            <Route index element={<Main />} />
          </Route>
        </Routes>
      </Router>
    </>
  );
}

export default App;
