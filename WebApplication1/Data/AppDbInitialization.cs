using EStore.Data.Static;
using EStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EStore.Data
{
    public class AppDbInitialization
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Companies
                if (!context.Companies.Any())
                {
                    context.Companies.AddRange(new List<Company>()
                    {
                        new Company()
                        {
                            CompanyName = "NVIDIA",
                            CompanyURL = "https://www.nvidia.com/en-us/",
                            CompanyLogoURL = "https://s3.amazonaws.com/cms.ipressroom.com/219/files/20149/544a0d86f6091d6699000060_NVLogo_2D/NVLogo_2D_362acb00-8e1b-476b-9662-9fe138a4a920-prv.jpg",
                            Description = "NVIDIA pioneered accelerated computing to tackle challenges no one else can solve. Our work in AI and the industrial metaverse is transforming the world's largest industries and profoundly impacting society."
                        },
                        new Company()
                        {
                            CompanyName = "AMD",
                            CompanyURL = "https://www.amd.com/en.html",
                            CompanyLogoURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7c/AMD_Logo.svg/800px-AMD_Logo.svg.png",
                            Description = "Advanced Micro Devices, Inc., commonly abbreviated as AMD, is an American multinational semiconductor company based in Santa Clara, California, that develops computer processors and related technologies for business and consumer markets."
                        },
                        new Company()
                        {
                            CompanyName = "Intel",
                            CompanyURL = "https://www.intel.com/",
                            CompanyLogoURL = "https://1000logos.net/wp-content/uploads/2017/02/Intel-Logo-2005.png",
                            Description = "Intel's innovation in cloud computing, data center, Internet of Things, and PC solutions is powering the smart and connected digital world we live in.\r\n"
                        },
                        new Company()
                        {
                            CompanyName = "Matrox",
                            CompanyURL = "https://www.matrox.com/",
                            CompanyLogoURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Matrox_Electronic_Systems_logo.svg/2560px-Matrox_Electronic_Systems_logo.svg.png",
                            Description = "The leading global manufacturer of encoders and decoders, IP KVM extenders, video wall controllers, broadcast developer, and infrastructure products.\r\n\r\n\r\n\r\n"
                        },
                        new Company()
                        {
                            CompanyName = "Apple",
                            CompanyURL = "https://www.apple.com/",
                            CompanyLogoURL = "https://1000logos.net/wp-content/uploads/2016/10/Apple-Logo.png",
                            Description = "Discover the innovative world of Apple and shop everything iPhone, iPad, Apple Watch, Mac, and Apple TV, plus explore accessories, entertainment.\r\n"
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>() { 

                    new Product()
                    {
                        ProductName = "ASUS Dual GeForce RTX 3060",
                        Description = "ASUS Dual GeForce RTX 3060 V2 OC Edition LHR 12GB GDDR6 Gaming Graphics Card (PCIe 4.0, 12GB GDDR6 memory, HDMI 2.1, DisplayPort 1.4a, 2-slot design, Axial-tech fan design, 0dB technology) DUAL-RTX3060-O12G-V2\r\n",
                        ImageURL = "https://ccimg.canadacomputers.com/Products/1000x1000/230/522/196353/73289.jpg",
                        Price = 399.00,
                        CompanyId = 1,
                        ReleaseDate = DateTime.Now,
                        Category = Enums.ProductCategory.GPU
                    },
                    new Product()
                    {
                        ProductName = "AMD Ryzen 7 7800X3D",
                        Description = "AMD Ryzen 7 7800X3D 8-Core/16-Thread 5nm 104MB Cache 120W ZEN 4 Processor - Socket AM5 5.0GHz boost, DDR5, PCIe 5.0, 100-100000910WOF\r\n",
                        ImageURL = "https://content.etilize.com/Main/1076567351.jpg?size=Maximum",
                        Price = 599.00,
                        CompanyId = 2,
                        ReleaseDate = DateTime.Now,
                        Category = Enums.ProductCategory.CPU
                    },
                    new Product()
                    {
                        ProductName = "Intel Core i7-13700KF",
                        Description = "Intel Core i7-13700KF Desktop Processor 16 (8P+8E) Cores 30M Cache, up to 5.4 GHz, 125W, unlocked, LGA1700 700 & 600 chipset, PCIe 5&4, DDR5&4, 13th Gen Boxed, Discrete GPU Required BX8071513700KF\r\n",
                        ImageURL = "https://ccimg.canadacomputers.com/Products/1000x1000/240/384/226953/31048.jpg",
                        Price = 519.00,
                        CompanyId = 3,
                        ReleaseDate = DateTime.Now,
                        Category = Enums.ProductCategory.CPU
                    },
                    new Product()
                    {
                        ProductName = "QuadHead2Go Q155 Multi-Monitor Controller Appliance",
                        Description = "Drive up to four Full HD displays from a single video signal—of up to 4Kp60 and 8Kx8K—at full RGB 8:8:8 and YUV 4:4:4 color support. The system-independent Matrox® QuadHead2Go™ Series appliance is designed to power any video wall configuration of any possible dimension, from any video source—reliably delivering flawless image quality across expansive video wall displays. QuadHead2Go’s on-device buttons and pre-set configurations ensure an out-of-the-box, trouble-free installation experience. TAA compliant SKU available.",
                        ImageURL = "https://video.matrox.com/sites/video/files/styles/maximum/public/2022-11/q155_appliance_front_angle_left_pad_800x450.png?itok=papWqOJ1",
                        Price = 1199.00,
                        CompanyId = 4,
                        ReleaseDate = DateTime.Now,
                        Category = Enums.ProductCategory.VideoWall
                    },
                    new Product()
                    {
                        ProductName = "Mura IPX 4K Capture & IP Decode Series",
                        Description = "Matrox® Mura IPX 4K capture and IP decode cards provide four HDMI or two DisplayPort™ 1.2 inputs for high-resolution capture of multiple physical and IP sources, plus high-density decoding of up to four 4K or 16 HD streams—offering an unmatched audiovisual experience. \r\n\r\nThese PCI Express® cards can easily satisfy system builder requirements through the mixing and matching of a wide selection of Matrox video wall components, delivering a scalable solution to accommodate any video environment. Ideal for control rooms, digital signage, AV presentations and other applications requiring high-density capture, streaming, recording, decoding and control.",
                        ImageURL = "https://video.matrox.com/sites/video/files/styles/maximum/public/2022-10/mura-ipx-4k-capture-ip-decode-series-800x450.png?itok=yaKZTmST",
                        Price = 1119.00,
                        CompanyId = 4,
                        ReleaseDate = DateTime.Now,
                        Category = Enums.ProductCategory.VideoWall
                    },
                    new Product()
                    {
                        ProductName = "LUMA A380P",
                        Description = "Drive two 8K displays—or two 5Kp120 displays—or up to four synchronized high-resolution displays or projectors from a single Matrox LUMA Pro Series graphics card. A single-slot PCIe® 4.0 x8 card with four native DisplayPort™ 2.1 connectors, A380P delivers superior graphics performance for today’s 8K HDR applications. For OEMs, system integrators, AV installers, and developers looking to create custom control functions, we also offer a complete range of video wall software, APIs, SDKs, and libraries.  Matrox LUMA Pro Series is powered by Intel® Arc™ graphics.",
                        ImageURL = "https://video.matrox.com/sites/video/files/styles/maximum/public/2023-04/luma-a380p-800x392.png?itok=2pVOXh6c",
                        Price = 435.00,
                        CompanyId = 4,
                        ReleaseDate = DateTime.Now,
                        Category = Enums.ProductCategory.VideoWall
                    },
                    new Product()
                    {
                        ProductName = "Maevex 6152 Quad 4K Decoder",
                        Description = "The Maevex 6152 quad decoder is a real-time H.264 video decoder capable of decoding up to four 4K live MPEG2-TS, RTSP, and SRT streams at low latency. When paired with Maevex 6100 Series encoders, Maevex 6152 can achieve exceptionally low latency at low network bitrate consumption. It also supports reliable, encrypted transmission over internet for the secure streaming of content. The complimentary Maevex SDK enables you to build new applications or integrate the functionalities of PowerStream Plus into existing applications. TAA compliant SKU available.",
                        ImageURL = "https://video.matrox.com/sites/video/files/styles/maximum/public/2023-04/maevex_6152_quad_4k_decoder_front_back_angle_pad_800x450.png?itok=nD-4aVPP",
                        Price = 835.00,
                        CompanyId = 4,
                        ReleaseDate = DateTime.Now,
                        Category = Enums.ProductCategory.EncodersAndDecoders
                    }, new Product()
                    {
                        ProductName = "Monarch LCS Encoder Appliance",
                        Description = "IT administrators will find this reliable, standalone network appliance simple to set up and integrate into any open Video Management System (VMS) or Learning Management System (LMS). Monarch LCS lets you easily define profiles for live streamed and recorded lectures by mixing camera and presentation material from SDI and HDMI sources. Once configured, this versatile H.264 encoding appliance can be operated by anyone at the push of a button. And it won’t break your budget!",
                        ImageURL = "https://video.matrox.com/sites/video/files/styles/maximum/public/2022-09/monarch_lcs-800x450.png?itok=w1klMPO5",
                        Price = 435.00,
                        CompanyId = 4,
                        ReleaseDate = DateTime.Now,
                        Category = Enums.ProductCategory.EncodersAndDecoders
                    }, new Product()
                    {
                        ProductName = "Monarch EDGE Encoder & Decoder Appliances\r\n",
                        Description = "The Monarch EDGE Series for remote production (REMI) offers 4K/multi-HD video transport for live, multi-camera events. Video professionals can select from a range of appliances to meet their remote production needs. The EDGE E4 4:2:2 10-bit-capable encoder is ideal for demanding, broadcast-quality productions. Programs destined for over-the-top (OTT) or cloud delivery can leverage the EDGE E4 4:2:0 8-bit-capable encoder. When paired with a Monarch EDGE encoder, the EDGE D4 decoder provides ultra-low latency, high-quality video transport.\r\n\r\nA simultaneous encode/decode appliance, EDGE S1 provides return feeds to multi-camera production crews in the field.",
                        ImageURL = "https://video.matrox.com/sites/video/files/styles/maximum/public/2022-09/edge_family_front_right_angle_smaller_800x450.png?itok=7aVQYVc7",
                        Price = 735.00,
                        CompanyId = 4,
                        ReleaseDate = DateTime.Now,
                        Category = Enums.ProductCategory.EncodersAndDecoders
                    }, new Product()
                    {
                        ProductName = "LUMA A310\r\n",
                        Description = "Drive two 8K displays or up to four high-resolution displays or projectors—up to 5K60—from a single LUMA A310 graphics card. Designed and built for reliability, stability, and ease of deployment, these fanless low-profile, single slot PCI Express® 4.0 x8 boards with four Mini DisplayPort™ 2.1 connectors deliver superior graphics performance for today’s 5K HDR applications. The LUMA A310 graphic cards are ideal for multi-screen desktops, workstations, and digital signage players in commercial and critical environments. Matrox LUMA Series is powered by Intel® Arc™ graphics.\r\n\r\n",
                        ImageURL = "https://video.matrox.com/sites/video/files/styles/maximum/public/2023-05/luma_a310_800x541.png?itok=y1UEIgEb",
                        Price = 1435.00,
                        CompanyId = 4,
                        ReleaseDate = DateTime.Now,
                        Category = Enums.ProductCategory.GPU
                    }, new Product()
                    {
                        ProductName = "LUMA A310F\r\n",
                        Description = "Drive two 8K displays or up to four synchronized high-resolution displays or projectors—up to 5K60—from a single LUMA A310F graphics card. Designed and built for reliability, stability, and ease of deployment, these PCI Express® 4.0 x8 boards with four Mini DisplayPort™ 2.1 connectors deliver superior graphics performance for today’s 8K HDR applications. The LUMA A310F graphic cards are ideal for multi-screen desktops, workstations, and digital signage players in commercial and critical environments. Matrox LUMA Series is powered by Intel® Arc™ graphics.\r\n\r\n",
                        ImageURL = "https://video.matrox.com/sites/video/files/styles/maximum/public/2023-05/luma_a310f_800x532.png?itok=B17_po3J",
                        Price = 1135.00,
                        CompanyId = 4,
                        ReleaseDate = DateTime.Now,
                        Category = Enums.ProductCategory.GPU
                    }, new Product()
                    {
                        ProductName = "M9120 PCIe x16\r\n",
                        Description = "The Matrox M9120 PCIe x16 ATX graphics card renders pristine image quality with dual monitor support at resolutions up to 1920x1200 (digital), or 2048x1536 (analog) for an exceptional multi-display user experience. Armed with 512MB of graphics memory and advanced desktop management, the M9120 drives business, government, and industrial applications with extraordinary performance on two high-resolution monitors in both independent and stretched desktop modes. It offers multiple operating system support and can be paired with a second Matrox M-Series graphics card if additional outputs are required.\r\n\r\n",
                        ImageURL = "https://video.matrox.com/sites/video/files/styles/maximum/public/2022-09/m9120_pciex16_800x450.png?itok=8YGIQi3x",
                        Price = 1235.00,
                        CompanyId = 4,
                        ReleaseDate = DateTime.Now,
                        Category = Enums.ProductCategory.GPU
                    },

                });
                    context.SaveChanges();
            }
            }
        }
    
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@estores.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Login12345!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@estore.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "user12345");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
