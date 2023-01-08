# BUILDING
1. npm i
2. ionic build
Every time you perform a build (e.g. ionic build) that updates your web directory (default: www), you'll need to copy those changes into your native projects:
3. ionic cap copy
Note: After making updates to the native portion of the code (such as adding a new plugin), use the sync command:
4. ionic cap sync

# ios/android projects
1. ionic cap add ios
2. ionic cap add android


# ios deploymnent
1. ionic cap open ios

# android deployment
1. ionic cap open android