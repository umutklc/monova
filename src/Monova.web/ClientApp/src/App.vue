<template>
  <div class="layout-wrapper layout-1">
    <!-- Layout inner -->
    <div class="layout-inner">
      <!-- Layout navbar -->
      <nav
        class="layout-navbar navbar navbar-expand-lg align-items-lg-center bg-navbar-theme container-p-x"
        id="layout-navbar"
      >
        <a href="index.html" class="navbar-brand">HTML Starter</a>

        <!-- Sidenav toggle -->
        <div class="layout-sidenav-toggle navbar-nav align-items-lg-center mr-auto mr-lg-4">
          <a class="nav-item nav-link px-0 ml-2" href="javascript:void(0)">
            <i class="ion ion-md-menu text-large align-middle"></i>
          </a>
        </div>

        <!-- Navbar toggle -->
        <button
          class="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#layout-navbar-collapse"
        >
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="navbar-collapse collapse" id="layout-navbar-collapse">
          <div class="navbar-nav align-items-lg-center">
            <div class="nav-item">
              <a class="nav-link" href="#">Link 1</a>
            </div>
            <div class="nav-item">
              <a class="nav-link" href="#">Link 2</a>
            </div>
          </div>
        </div>
      </nav>
      <!-- / Layout navbar -->

      <div class="layout-container">
        <!-- Layout sidenav -->
        <div id="layout-sidenav" class="layout-sidenav sidenav sidenav-vertical bg-sidenav-theme">
          <ul class="sidenav-inner py-1">
            <li class="sidenav-item" v-for="(item, i) in items" :key="i">
              <router-link :to="item.link" exact-active-class="active" class="sidenav-link">
                <v-icon :icon="item.icon" class="mr-2" />
                <span>{{item.title}}</span>
              </router-link>
            </li>
          </ul>
        </div>
        <!-- / Layout sidenav -->

        <div class="layout-content">
          <!-- Page content -->
          <div class="container-fluid flex-grow-1 container-p-y">
            <router-view />
          </div>
          <!-- / Page content -->

          <!-- Layout footer -->
          <nav class="layout-footer footer bg-footer-theme">
            <div class="container-fluid container-p-x pb-3">
              <a href="#" class="footer-link pt-3">Link 1</a>
              <a href="#" class="footer-link pt-3 ml-4">Link 2</a>
            </div>
          </nav>
          <!-- / Layout footer -->
        </div>
      </div>
    </div>
    <!-- Layout inner -->

    <div class="layout-overlay layout-sidenav-toggle"></div>
  </div>
</template>

<script lang="ts">
import HelloWorld from "@/components/HelloWorld.vue";
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: { HelloWorld }
})
export default class App extends Vue {
  private clipped: boolean = true;
  private drawer: boolean = true;
  private miniVariant: boolean = false;
  private right: boolean = true;
  private title: string = "Monova";
  private items = [
    { title: "Home", icon: "home", link: "/" },
    { title: "Counter", icon: "touch_app", link: "/counter" },
    { title: "Fetch data", icon: "get_app", link: "/fetch-data" }
  ];
}
</script>
