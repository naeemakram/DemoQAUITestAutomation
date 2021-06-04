using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQAUITestAutomation.Tests
{
    class TestConfig
    {
        private static TestConfig testConfig;
        public static TestConfig Instance
        {
            get
            {
                if (testConfig == null)
                {
                    testConfig = new TestConfig();
                    testConfig.SetupTestConfig();

                }
                return testConfig;
            }
        }

        IConfigurationRoot _configRoot;

        private void SetupTestConfig()
        {
            _configRoot = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
        }

        private TestConfig()
        {
            
        }

        public string URL
        {
            get
            {
                return _configRoot["url"];
            }
        }

        public string StudentFirstName
        {
            get
            {
                {
                    return _configRoot["studentFirstName"];
                }
            }
        }
        public string StudentLastName
        {
            get
            {
                {
                    return _configRoot["studentLastName"];
                }
            }
        }
        public string StudentMobileNumber
        {
            get
            {
                {
                    return _configRoot["studentPhone"];
                }
            }
        }


    }
}
