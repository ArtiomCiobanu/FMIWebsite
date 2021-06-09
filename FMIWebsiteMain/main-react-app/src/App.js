import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { Layout } from "antd";
import { MainPostsPage } from "./pages/MainPostsPage";
import { PostPage } from "./pages/PostPage";

export const App = () => {
  return (
    <Layout style={{ background: "white" }}>
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
