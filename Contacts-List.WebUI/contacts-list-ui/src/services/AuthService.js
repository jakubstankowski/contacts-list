import decode from "jwt-decode";

export default {
  saveAccessToken(accessToken) {
    localStorage.setItem("accessToken", accessToken);
  },
  saveRefreshToken(refreshToken) {
    localStorage.setItem("refreshToken", refreshToken);
  },

  saveUserDetails(user) {
    localStorage.setItem("userId", user.id);
    localStorage.setItem("userRole", user.role);
  },
  getAuthData() {
    const token = localStorage.getItem("accessToken");
    if (!token) {
      return;
    }
    return {
      token: token,
    };
  },

  getAccessToken() {
    return localStorage.getItem("accessToken");
  },
  getRefreshToken() {
    return localStorage.getItem("refreshToken");
  },
  getUserId() {
    return localStorage.getItem("userId");
  },
  getTokenExpirationDate(encodedToken) {
    const token = decode(encodedToken);
    if (!token.exp) {
      return null;
    }
    const date = new Date(0);
    date.setUTCSeconds(token.exp);

    return date;
  },
  isTokenExpired(token) {
    const expirationDate = this.getTokenExpirationDate(token);
    // @ts-ignore
    return expirationDate < new Date();
  },
  clearAuthData() {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");
    localStorage.removeItem("userId");
    localStorage.removeItem("userRole");
  },
};
