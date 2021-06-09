import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { Layout } from "antd";
import { MainPostsPage } from "./pages/MainPostsPage";
import { PostPage } from "./pages/PostPage";
import { NavBar } from "./components/NavBar";

export const App = () => {
  return (
    <Layout style={{ background: "white" }}>
      <NavBar />
      <Router>
        <Switch>
          <Route path="/posts/:post_id" component={PostPage} />
          <Route exact path="/">
            <MainPostsPage />
          </Route>
        </Switch>
      </Router>
    </Layout>
  );
};
