using APIBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackEnd.Data
{
    public class BoPeepDbContext: DbContext
    {
        public BoPeepDbContext(DbContextOptions<BoPeepDbContext>options):base(options)
        {

        }

        /// <summary>
        ///  This lies where our composite keys are constituted and seeded data are added
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagActivity>().HasKey(x => new { x.ActivitiesId, x.TagId });
            modelBuilder.Entity<ActivitiesReviews>().HasKey(x => new { x.ReviewsID, x.ActivitiesID });
            modelBuilder.Entity<Activities>().HasData(
            //Dummy data for out Activities table
            new Activities
            {
                ID = 1,
                Title = "Hike/trails",
                Description = "A nice stroll outside to enjoy nature and fresh air",
                Rating = 4.50,
                Location = 0,
                ExternalLink = "https://www.wta.org/?gclid=CjwKCAjwvtX0BRAFEiwAGWJyZJMy_TIYVTxTlNY1u8DtYnwh-hfOyaf4tLByYfEdTrqNR2JbN8hk5xoC2-4QAvD_BwE",
                ImageUrl = "https://lh3.googleusercontent.com/wsKJqFBi1OBzZYO6Dpb6RuoGLi2KuVqYJBbqmSWKV-eCEvtu0kfg4WNAtuzKKspUycD2QpUJgcExN3DCCwUh-eNFXaAo_WHWSTa8YceU7BNKBiwsHVbpg29_HEIa0EfvxMPu2Vs2T_52i__VHGcGUtuQuKD7kLSxRAlYmPDWHvCJabdz0RUbv6LF8NKiUdcGxAjFMqBoJcFPE_A-etDjgXeAMPwelYOzfXHcx6Nx0EnrBKMCW9Z65dF3Lb_sFrfN6BOCdwHvENG_dbHadzLA3msUyUtJcVt_DFAOczg0magsj16lxpTM1vjZiMhkP2EGKLnH72PdLamLyyr6S11227_1FWn-iGA0FasdUFjlt5noePZ6oJ7KY94U2aBycat2jSl2ATnW9A-_DLkxsC9hVZzQrExshJkmcuXHhWlQwZjbTb22I-yPaegZ43saWgIz-tw4RRz8m2immyC90QJAKxxhUrLMaMPbLvVCEw1vYyUSt38fDm9NVLydd8qWCc-K6_8MsfKbf9ItJZhJT8cFWbtpxk7XP3i8yjs7UPEH3aggGGpXduh5hLYQ7syA199Z2RsO46tomty2DNu9FJ6Db68255vMrXIb8CcML4RgMFbK8s5bI3g3X7hufWSHbyT78dc2EkRlk8bxEFWRVOpQ0qH4CcOlQIEDnJmzHkRvqdfJqm9AvaAGCEQ7ntodtaXVNFH8ZnZmBWh8bT2socopHIiOxkeu6QkiO1XUet95k957sIfHfM2bWQ=w640-h959-no"
            },
            new Activities
            {
                ID = 2,
                Title = "Bird watching",
                Description = "A chance to enjoy nature without movement, also good to enjoy with your cat",
                Rating = 4.50,
                Location = (Location)1,
                ExternalLink = "https://www.seattleaudubon.org/sas/getinvolved/gobirding.aspx",
                ImageUrl = "https://lh3.googleusercontent.com/dMy39yWApD2SDS_SizgMKiw_aQa7qQnQXJfJTC1K9JPiDi4dJtyyOylY5Z7b-I786UyQ71iN9i64yQ0EZiJRLtXC2NqaJLVGBuzyVtNDHePezsmiNZPj4-mICvHWWc4lK9Nw06Pry4n3hJZSM8YcM4LR80hkZOteuAzLKn3wLmj_h_6Nv-oAk99vBdiuXwXYyTXO1bAV5mLkJ3v4FYhm37TsRpY1aBSc3Fi3B_en55X0ry2Z4DmlPyX1FfHkEsu897kUCehvIO98cqmPNNzx6sHmTUkdKOaNuJVcrGoQh_1YpHWLw-kkG8Lsknv-8TaSozRlKkI9kIQMSlPDmBDPEDG7GOrtEDCQ9YIpydbjqTHdhprHSSr7s87bj9Vcizx9AExi2Eu7SLoJqj_Ml0zyZXhuORUb0Z9n_kIbDfZsWSC3psFU5DlD0nV-_Uqmiuv6_aPDAPrAkxXlks7tuwIHJj26ajoBMq65eGSgSAIS3zMxy0CDWIEooz1xYdesWHpna71M0bGVBAH-JXJMNZLpzlYpMzwfEnVEi0MBDiGv2SfDT-9uoJRlSRyC0ZbppwG6C2tsJFqMKnMWrABbq9eOquSsVLFR9jAfDmRyjul8gAQ_Hvz7_H3OKMGg2hhxjX6sJZpaC0lxgS3mxMv3zAPwdMUOBiGz7Ou0vzmZQ_vpbTVzfIMdTNb0ideYSQ4JxMh8jpwygEizFYx9Vf7hStoD2PgQ7XVU-1l9QCiLo1iLY25NuNPz8u-t1A=w792-h645-no"
            },
            new Activities
            {
                ID = 3,
                Title = "Dog/cat walking",
                Description = "Better than a hike! You've got companion to help you stop and smell the roses",
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://lh3.googleusercontent.com/JwS4zS0X-x2W_PuqpEOy1j4nX50hXj21tzcP4EsIcmypDMndEKvjNkMMmAIl9BMkAHiBxl0B2-DLRVOhL84Rlz8qiA6myQW_Jt1RrypZOSsZ9fo_bDJXtxyjUDW8LGi3bRx7IPJToMGkGO6MH-KcTVXRiB5oEOigeA4qAWcGaT3fwCTQ8a8kZM1yTtZjTaY5PtwcMXQjUWme97uv8IP4AB8_bSmU99wDqfaHCTA-eOURrp1V9ehJ8-2xvQuHdBY884HjgDIEjt_TwXWn2HbEF7F6bLW9v577AArIQwU9JgQ7x1Q4_r4Z7PdTtBipH8jZpkeLJcQwP4_LwRmFuCyzK-_xQa3Soa3JbVPW3qA43eoFhXKOG9uN-A6HKA6Qnq_UTC6rwJ3JimX_HEaqXao5IAF-xNY7usgDiAbdlF1sTjko2b5oLKj_w3sJJFClYrUGLvAPTOkQPkNHgbyxloj9ta9PfocByQx3xbsq_wlK2Z_irRh6QQlVhd3y2DL3wH5wuxD5vdj88hIteWAbNovdIwOEJ7P6jB_7fMoPLfV3saAZcxX6a-nmnBBPRgcuO0bcMXbVd55bg5-tTKNezgzX7S1-4lZ5KdnIUgdbfKckKJuadEnmQ2S4ye0doLPt-VTa44X-tBdND_y-pYaJPE418pxBTCiUSPL_CpgvrEnDUyrZOtrkYGRqqRHAUcJlwaKpmCMWB4qDiyG7x56Tb89aEvOZfmlcevWzVj3k24SBAq1RW9OEB7VU3w=w792-h528-no"
            },
            new Activities
            {
                ID = 4,
                Title = "Gardening",
                Description = "grow veggies, flowers and fruit",
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://lh3.googleusercontent.com/XY-PZWOqUIGpnYw_-A6LnNqcOLoTdWuWqLaA5tILpkkbvXXZ0u25y2KpEIERcCTar_rwdiCYrmwnrU3AIGHclD9hP_llaBF3B6bHyPg5rLxauUh0aehOvuY22bFcRzDNSAPhNyFDy1gr_hQZeN0k8d-re-DI0DyRmef_-W-nUE-90ZCtYLUEaGWYex_ITT6J9tydBjMZVZljFsVeE-FliOAlv-crPSmKP-PtbyS2kHWXZ7qCh4oGzZEMOY2mNtymRZQYSHVLZ6Q6F-Y8NLS_mmeqJvb-Ii0w2F4oMlnBgmfNZTUDdR8MLq_iHgOkxzry85fO2LHxgBiZvJw-aWFCY8V2KhTtt4Pd91fNZIXQnueTjTfOHuZqLw3EjlPwv4LLVvFkn57xiEyQ7LwsjlR_0svFi1WwOAtjVW-xUyKYVZGBSsi7UoDGct8xTqgOvUm-Msbtd5jmpO5Ntb0taJtdJOx8KZqrrPbRQiAEQAtpaU8-CT316yy5mmqGzuilbgL64n_9jyjq6TN_tbBr8IVgfILFAcHXkWiSEKBfKFlFoKMoeO4Ltr_lgZNni2_iEOit-zAuAtXh948Bkgkh6g-SUe9Tld6a8AU8IXRD63qAQL38tK5e7Xf-LkbZwTzD9dATcclWFAne8YEbUWJmjbGXTO2dAktBikq-aT2ByCJ4quTSGeuA1aM0NIX-i6YO_C61aDbme_sQe1YXHrJ6jmXkiJgMSv4xh-xCVD8qK0SwPXWmMK2avHPz_A=w768-h959-no"
            },
            new Activities
            {
                ID = 5,
                Title = "Dumpster Diving",
                Description = "Get a nice bite to eat, for free!",
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://lh3.googleusercontent.com/to2fp-5CAcP0VGgDim_0BljQzhWINHFq7w9BpBSUr01HlTPC0LN7UvjDhUfiH5BBAoEdnMUkBemsK7wUPWER3F2EE9ziBT-ppJ_bFLup7l4AIY6MWajxygsaBtW2lTNJ4bS9L2FPt4nTsHPnjbzUPGavTQ1-2mlUL6mASNzpHCqnDIkX1p30z_JUYzJYPXmshtZlki1KofWfgMj6Smo13PNTVAOzfnwzuv-Wnr2f8Zr2Zrh1Ixo1GxU3UzgdsRo4ICU-uYVIfsvL1RDM2VwzQPODFp8HU74-FjEhP2W1CG0JpPA1WgGhXFBVFZTcdu9a4mKcHAaDwEyk9UGyei1O2IMkeHa10EkbcYvAmsIIoOz0O5DDkYTRiuKgdoYTn6UMB9sz4qVURzJnjSmw_iCsLlpYJMp3VeevH2P4-7OO-0i44-clyCG6UyofoeyjZ-FVG6qH-4ObJLZGe_aK9S9hQsUsns1XMipQ3OTFMLyh-Q4Z1xCwcmaixp_dwIqSOCz4FJrUg7sMdstVPlk6nzttZq0QJSgFhSoEAMGCATHbsh_z8Ou6spvt2Sva4Ai74FWRINrUsIRY8ePlRArLkFS_iUOUZ3r9bf_8jTdVvOoEUjH0R7tNIOU1r6ajPQp0wVg3NFfRgqJ14gMdejcTAoqE_FXzN9xEiWEOthCiKDb_Lq0XcKwxHIou0_ShEn6lS5RjxVr1oHjvS5Jn826tzK9SawFcjt8vf-u872sKYsYQqGiMjNN44ekZqw=w640-h960-no"
            },
            new Activities
            {
                ID = 6,
                Title = "Games",
                Description = "Time to slay dragons and drink mead",
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://lh3.googleusercontent.com/j21UAz5V4kWgTqzb8BrdZinN7cLwOpF3inktl4k2G6eK5z70LEhZvhVd9Qfues5L23WRsGgesbe4rkfqknjyQV9SspzIBsOEVkFfrREKzYQbaeFN5WZjGUI_rrXl8KZLPDyBB2G1RywuKxh4dpmpi0akNS3dMS1t1xIpklZGpM6WBcOXcFnS6sgQ2227wK8E7oSQE11XiOiqbO6hqJut2bravf6Q7KoNV3_ZvzeEY2k_payjSNbr0qiUbHc5Boz1JI3Ytadd40h4xS06mM-RDyEZ6sd_ld6wXefrEXttnBQidWNthegeC9rZnIGiJjGxnPwju4AB9csmgXz9fCOMnBM8KkahPPEbbqxUkgpGH9cb3B4cKC0-PXKCDFGv5aUA187bKVYaUNh3XmW4w-8Bx3tMCPt9w3Umpw4J4a7P7cvcKeZmx6iNbIWpF3wPivp0fBHPvz3C0mzOldZ--gI0KUgImza50xCNryxatYg6DWvXyU_P8AMT9ZKO_nCv8893iDZT8Oxdq9ErnyReNy77FQs8aHszUyaX6tx-DTMz7EeEs2xQlyxogeSOh7yXhRRNXnGB6cbrNiyExjxaQ4-QIQH69qoK8MNjTJJMsw2rwO4NVd59PhH6PG84NvOriXviWERz-EZD0ax5HEOszVSPb-9Fh-Ln6SFWs3at3t2JOEadxpb_0knjUlky4z6xcoqrtca0JVMG1Boxnac2C8hFofmUkNlELidn6HlgsG_HM81mJol0pDAWCQ=w792-h528-no"
            },
            new Activities
            {
                ID = 7,
                Title = "Exercise",
                Description = "Blood pumping and brain working",
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://lh3.googleusercontent.com/00IDy6EJ0OYAiRxHQhJN25AYVodYJ-x_tdpsoWpU6a8KwFdD8-XJ6SYirb5OYv5dhS-qLNn1gPEAifBcELgPxBcNPqc9IY_QLV_xJxYeH07_HNmfJuOMqC-_tupX4p0Bnl2WwSF79bv8iggmnnQcrfPr3I8y2gEVqMDVrObg6KS1IsRXy-m7R1xx1plX7_3KBolPxdFQw5K1g5Kp9E2y1NL-e5_sihUYytKwxP9B6Gvb0qYSGz3LBxAYpX69GtKvKaNYHb6Oa1ZWw7z1VnssqIjcnSVGRzvbnMVtEEebUEHRZFs7OSc86257X4crIWT6NshDCT94hzsR_uNCfSRBmR0ILay1KfPS8bSiaNCOUWgswl0RY-lKPy4DNqkDcot68UUMqUFT_lNIF_FOIsJuO9m-0VRvpjnQuU6DGWR47fyytkALce3vmTjJJdSbJeBfZOsH921hf3rbd1VOPZN8in33t0Yd4ABlRK_0agLTQ6mrYwKA2YXxwpTlztpv_gDft4WCLcHu1MirWXGjFzXJd19FYYOapO6ej0JFWgmXsd8OdgS3gPD2Gn0W4em2iymbis2kctTfsafpvVj32dU7PsoHAEH8FpbA7sHoZHWzwODEUsWmD7DToOCMU7FQI5ovvlc2opHh7CLDT3xF0fyY62U5BgFLE7AGmV6e1rh0gs6SUt8rvlPA83KSGZjmqBCprgz6QKS38SXgOBcRKh8irtR1txncFJPfKD9fh3JO_aFDgscYjzJAeQ=w793-h528-no"
            },
            new Activities
            {
                ID = 8,
                Title = "Learning",
                Description = "Art, cooking or C#, the options are endless",
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://lh3.googleusercontent.com/AW8WjnWmwACwyPblM18n0f5kUTwNmtZqR-us7Ze37fbtJTsnnP8uGffnLhdaj-unnFYh58wA00KryN1vhnoamzSE1C1KnnBcGMNuq3GZW9P3k5qXHYiG1cFlGmpBnmoCNBh53RkKRrEJYNLCcyjrcHOIwMB6i_u2s-al2_eG49s9HJpk3QWQQIZ4fIYzFLPxgChaXIY1UdXU59bQjcYteXPkrOXMRY6m6RUsXEcL6fyTcFweq8P3vWncHaGiF_67AE_nRYqiHhVrNo5AvfX1yHSQVPpX58UOukvLUsY3ImSDVyz3OyLsevdjcTS_BbbgGurB8YxoYF_i91C8USiC0OTbYMCjAmYZGJ4BoRS-oSyD4BacSjBQL_qGF_P4yAvdrjb6RZPz5ugfR2jS9sWHl1D9UWLPMfvAwaM_Cmasmr1XEnnFWassI5QAliQaUoTjWI828qD5EaEbDrRQIt8r-uBQAepMX_ORn-nDg-zZybMVPvJ5uD-WH6rxT37yvhjTXkrsx1HNgN81N7KaTpQ8gPKo5wlHiselhzkKAjzhtBRuXxYn4g3ZDA7pfy3PNpvIg3blLBa4khRWrT3WX_Jjjk9wN7TXX2TDBAe1xWNUlnIWFp2CxJSX3KNbzeZej5EU9Tf2dL-TSdWJv7SJ-L3pLBJb8b1fBr2Y3tUUMIV0Xbh8yTj4PHfPckY01wM394ckJJp1No6nzmow-7w3yrSpLNb2kzB9liEC5-7u11AArqSlh8gk5LeGxQ=w792-h529-no"
            },
            new Activities
            {
                ID = 9,
                Title = "Terrariums",
                Description = "Aloe, succulents and anything else your cat won't eat",
                Rating = 4.50,
                Location = 0,
                ExternalLink = "http://serpadesign.com/",
                ImageUrl = "https://lh3.googleusercontent.com/8cND4vNQ_1P2HGAUISgSSrBPHoDhJGLVmYLNVw6sg3B-uJSSZcQMD4ITmYYLZ1dcFtKSjCz-GHMda1ceMH1izJNMg0B_QB27BffI6V_VtZvBjEM36f_OKkQ8Zr884GCtCyWv0aD88VFtDZwuFIhWaImXeYV050lJ1kVA3YBWf-unU8_dNFOUxjZ7hTTjxEFnWYfQSRbrYQ8c6EHTCVLXTax7NESwi8Nh16zyCpuSRZaNtgtyNPbSEJcX2nTN5CBC16bmKRdvZsnuZN8u96qsNQv4mPdHOHpzRo4IB9A4rJRBCZAeagEhnyksnwWQ2S1uqWWMYVTsY_PXym51p6FpzGgIYEYxOBDTEETv7i4Y-XBLQcVpMvaF2YfzJ8hDRmef7JRimGl5VuamAI-98VX6WsWInnH2xvwKJncd3r6Mt1_e3AerBd0Pf2iluCeIMnVsMMapn0re2uaQ89nC5Cviw-iQ0HuDm7ridYAMB9U3QgWdR-w4XB6iHhHFZfCwj5fMlMdbAavVS7DqlUQpD3eRQEFfie6ZxOa7ApF8XaerUD4jctvDN-dTJxOuIPaYNu0TA2CuyB2FveT88E1okzwxtfNLC3Ys5Q3YWFPxfLeThceonRUJrw_IiEF74OUAOc7dCRJhtH-PRcEM42HqbdhbSKKSZSQJLgwvtkZHSzxY79At6VygpFDgA2oT52JsYNkXta-_o-oMMyyI_HHFbRILLODlyDdmQFPX9b0hnAskoC8QeUf-2JYvsQ=w768-h959-no"
            },
            new Activities
            {
                ID = 10,
                Title = "Facetime/video calls",
                Description = "be social while social distancing",
                Rating = 4.50,
                Location = 0,
                ExternalLink = "N/A",
                ImageUrl = "https://lh3.googleusercontent.com/QUjBLgAyezIlxLFiTanm5wRwdPHO-Q-_6CH4Au3_CzLH1yetGmREeEC2IBY7mP7yf7-C12VR3Hpa3P--DXhzcJ_Nism__-NERuYy21TYaX8d0K4qbPoxV8XH205ZRBps-VagjJ2NG28hKYalVIYe_oj5sZ4y30SK7qNr2QnLPPUMtlrC_INaFwC76b4r4lR3sDX6zVxywBiSmNN1m7RkVW6d4hVPdnz-GDEhyieH2YIiIeadQxXkEZMPP8XUqFCcl9XkweJCejPuEolyxMREgka3RDvhy0HUESxHeJ-aTlJcjidzmBM2NURZ0mVvXqmzexdswOq-Ui0IovWFQ5bByXhNrUtw-tLn2j63-9YSBGT81BgZixEWNXQNTKvfsqPivGVgFIN-7-908JNnj101XgtzEMtjgIZ-gfY5OM8sMmGqeHge-ofmHf1J2SRYaG7Ul9Qtq6Str9cqT8PvEiZmeyV_I0PSvT3L_3-j3qUM8-gDY5HgOIVHZfrIo19-sI-Rwp5-JJeoxcHWrnRu0QmKh2bVf_82owrk79M5RQyY8mltw-7BqAqYKbx96coZCs7k79_FqAKpjDQ1AgaXzAZO3h1im3mTBEVKyYxHYvu4cthEqftc2rkAmld11IP7HyB7pVkmigJ9z0yMFqjgXBCEHyV1FGDMiZIvLvllmonP0fJyO8Je9J45WbnpNsc1p44RJFnzCYELMP7IOz55ZuR8KVnEsBpdhtRkR2z6x-GbaLPUk3c8e40hdQ=w639-h959-no"
            }
            );

         modelBuilder.Entity<Tag>().HasData(
            //Dummy data for out Tag table
            new Tag
            {
                ID = 1,
                Names = "Flora/fauna"
            },
            new Tag
            {
                ID = 2,
                Names = "Exercise"
            },
            new Tag
            {
                ID = 3,
                Names = "Games"
            },
            new Tag
            {
                ID = 4,
                Names = "Social"
            },
            new Tag
            {
                ID = 5,
                Names = "Pets"
            },
            new Tag
            {
                ID = 6,
                Names = "Arts&Crafts"
            },
            new Tag
            {
                ID = 7,
                Names = "Self care"
            },
            new Tag
            {
                ID = 8,
                Names = "Online"
            },
            new Tag
            {
                ID = 9,
                Names = "Productive"
            },
            new Tag
            {
                ID = 10,
                Names = "Baking/Cooking"
            }
            );

        }

        /// <summary>
        /// Sets of model that will be added to the database
        /// </summary>
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Reviews> Reviews { get; set; }

        public DbSet<Tag> Tag { get; set; }

        public DbSet<TagActivity> TagActivity { get; set; }

        public DbSet<ActivitiesReviews> ActivitiesReviews { get; set; }


    }
}
