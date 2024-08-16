load("@bazel_tools//tools/build_defs/repo:http.bzl", "http_archive")




# rules_pkg
http_archive(
  name = "rules_pkg",
  urls = [
    "https://mirror.bazel.build/github.com/bazelbuild/rules_pkg/releases/download/1.0.1/rules_pkg-1.0.1.tar.gz",
    "https://github.com/bazelbuild/rules_pkg/releases/download/1.0.1/rules_pkg-1.0.1.tar.gz",
  ],
  sha256 = "d20c951960ed77cb7b341c2a59488534e494d5ad1d30c4818c736d57772a9fef",
)

load("@rules_pkg//:deps.bzl", "rules_pkg_dependencies")

rules_pkg_dependencies()




# rules_distroless
http_archive(
  name = "rules_distroless",
  sha256 = "8a3440067453ad211f3b34d4a8f68f65663dc5fd6d7834bf81eecf0526785381",
  strip_prefix = "rules_distroless-0.3.6",
  url = "https://github.com/GoogleContainerTools/rules_distroless/releases/download/v0.3.6/rules_distroless-v0.3.6.tar.gz",
)

######################
# rules_distroless setup #
######################
# Fetches the rules_distroless dependencies.
# If you want to have a different version of some dependency,
# you should fetch it *before* calling this.
# Alternatively, you can skip calling this function, so long as you've
# already fetched all the dependencies.
load("@rules_distroless//distroless:dependencies.bzl", "distroless_dependencies")

distroless_dependencies()

load("@rules_distroless//distroless:toolchains.bzl", "distroless_register_toolchains")

distroless_register_toolchains()




# rules_oci
http_archive(
  name = "rules_oci",
  sha256 = "46ce9edcff4d3d7b3a550774b82396c0fa619cc9ce9da00c1b09a08b45ea5a14",
  strip_prefix = "rules_oci-1.8.0",
  url = "https://github.com/bazel-contrib/rules_oci/releases/download/v1.8.0/rules_oci-v1.8.0.tar.gz",
)

load("@rules_oci//oci:dependencies.bzl", "rules_oci_dependencies")

rules_oci_dependencies()

load("@rules_oci//oci:repositories.bzl", "LATEST_CRANE_VERSION", "oci_register_toolchains")

oci_register_toolchains(
  name = "oci",
  crane_version = LATEST_CRANE_VERSION,
)




# rules_dotnet
http_archive(
  name = "rules_dotnet",
  sha256 = "14735664c4f9dff606923862c196810ba2aa8a9deb17474d265fbdf09a94a9e2",
  strip_prefix = "rules_dotnet-22568f4906d0786f35b9cc6dc67516126f8f11db",
  url = "https://github.com/bazelbuild/rules_dotnet/archive/22568f4906d0786f35b9cc6dc67516126f8f11db.zip",
)

load(
  "@rules_dotnet//dotnet:repositories.bzl",
  "dotnet_register_toolchains",
  "rules_dotnet_dependencies",
)

rules_dotnet_dependencies()

load("@rules_dotnet//dotnet:paket.paket2bazel_dependencies.bzl", "paket2bazel_dependencies")

paket2bazel_dependencies()

dotnet_register_toolchains("dotnet", "6.0.200")

load("@rules_dotnet//dotnet:paket.rules_dotnet_nuget_packages.bzl", "rules_dotnet_nuget_packages")

rules_dotnet_nuget_packages()

# paket
load("//deps:paket.main.bzl", paket_main = "main")

paket_main()




# deb indexes
load("@rules_distroless//apt:index.bzl", "deb_index")

# bazel run @bullseye//:lock
deb_index(
  name = "bullseye",
  lock = "@@//:bullseye.lock.json",
  manifest = "//:bullseye.yaml",
)

load("@bullseye//:packages.bzl", "bullseye_packages")

bullseye_packages()
