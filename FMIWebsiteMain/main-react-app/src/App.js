import React from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import { Layout } from "antd";
import { MainPostsPage } from "./pages/MainPostsPage";
import { PostPage } from "./pages/PostPage";

export const App = () => {
  return (
    <Layout className="layout">
      <Router>
        <Switch>
          <Route path="/post">
            <PostPage />
          </Route>
          <Route exact path="/">
            <MainPostsPage />
          </Route>
        </Switch>
      </Router>
    </Layout>
  );
};
